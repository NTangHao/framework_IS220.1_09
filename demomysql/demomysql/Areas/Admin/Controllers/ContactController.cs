using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demomysql.Models;
using System.Net;
using System.Net.Mail;

namespace demomysql.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public ContactController(linhkienchinhthucContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult ContactUs(int? id)
        {

            ViewBag.Message = TempData["guimail"];



            var contact = _context.Contacts
                .FirstOrDefault(m => m.Malh == id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewBag.lienhe = contact;
            return View();
        }



        [HttpPost]
        public IActionResult ContactUs(SendMailDto sendMailDto,int? id)
        {


            if (!ModelState.IsValid) return View();

            try
            {
                var contact = _context.Contacts
               .FirstOrDefault(m => m.Malh == id);
                if (contact == null)
                {
                    return NotFound();
                }
                ViewBag.lienhe = contact;
                

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("tenmailnguoingui@gmail.com");


                mail.To.Add(sendMailDto.Mailto);

                mail.Subject = sendMailDto.Subject;


                mail.IsBodyHtml = true;

                string content = "Họ tên : " + sendMailDto.Name;
                content += "<br/> Nội dung : " + sendMailDto.Message;

                mail.Body = content;


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                NetworkCredential networkCredential = new NetworkCredential("tenmailnguoingui@gmail.com", "matkhau");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                ViewBag.Message = "Gửi thành công";
                contact.Tinhtrangdon = "Đã phản hồi";
                _context.Update(contact);
                _context.SaveChanges();
                TempData["guimail"] = ViewBag.Message;
                ModelState.Clear();

            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message.ToString();
                TempData["guimail"] = ViewBag.Message;
            }
            return View();


        }










        // GET: Admin/Contact
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: Admin/Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Malh == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Admin/Contact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Malh,Hoten,Email,Noidung,Tinhtrangdon,Ngaygui")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Admin/Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Admin/Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Malh,Hoten,Email,Noidung,Tinhtrangdon,Ngaygui")] Contact contact)
        {
            if (id != contact.Malh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Malh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Admin/Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Malh == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Admin/Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Malh == id);
        }
    }
}
