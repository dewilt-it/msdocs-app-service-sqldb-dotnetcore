using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
/*using ScanApp.DAL;
using ScanApp.Models.Device;
using ScanApp.Models.Instance;
using ScanApp.Models.Session;
using ScanApp.Services;
using ScanApp.Models.Dialog;
using ScanApp.Models.Dialog.Control;
using ScanApp.Models.Dialog.Action;*/

namespace ScanApp.Controllers
{   
    public class AppController : Controller
    {        
        /*readonly InstanceService InstanceService;
        readonly LicenseService LicenseService;

        readonly ConfigurationExportService ConfigurationExportService;

        readonly ScanServerContext Db;                

        public AppController(InstanceService instanceService, LicenseService licenseService, ConfigurationExportService configurationExportService, ScanServerContext db)
        {
            InstanceService = instanceService;
            LicenseService = licenseService;  
            ConfigurationExportService = configurationExportService;          

            Db = db;
        }*/
        
        public async Task<IActionResult> Index(string instanceCode = null)
        {
            //if (!LicenseService.IsActivated()) {
                ViewData["Error"] = "License error";
                ViewData["ErrorMessage"] = "The product has not been activated.";

                return View("Error");
            //}

            /*bool formPosted = (Request.HasFormContentType && Request.Form != null);

            if (formPosted && Request.Form.ContainsKey("scanapp_device_fingerprint")) {
                HttpContext.Session.SetString("scanapp_device_fingerprint", Request.Form["scanapp_device_fingerprint"]);
            }

            DeviceService deviceService = new DeviceService(Db);
            Device device = deviceService.GetCurrentDevice(HttpContext);

            Instance instance = null;
            DialogService dialogService = null;           

            try
            {
                if (instanceCode != null)
                {
                    instance = Db.Instances.Where(x => x.Code == instanceCode).SingleOrDefault();
                    if (instance == null)
                    {
                        throw new Exception("Instance '" + instanceCode + "' does not exist.");                        
                    }
                }
                else
                {
                    instance = Db.Instances.Where(x => x.DefaultInstance).SingleOrDefault();
                    if (instance == null)
                    {
                        throw new Exception("No default instance exists.");                        
                    }
                }

                if (!InstanceService.IsRunning(instance.Code) && instance.AutomaticStart && instance.ConfigurationId != null) {
                    InstanceService.Start(instance, ConfigurationExportService.GetConfiguration((int) instance.ConfigurationId));
                }

                dialogService = InstanceService.GetDialogService(instance.Code);
            } catch (Exception e) {
                ViewData["Error"] = "Error";
                ViewData["ErrorMessage"] = e.Message;

                return View("Error");
            }

            Session session = null;        
            if (device != null) {
                session = Db.Session.Where(x => x.Id == HttpContext.Session.Id).SingleOrDefault();

                if (session == null)
                {           
                    session = new Session
                    {
                        Id = HttpContext.Session.Id,
                        Start = DateTime.Now,
                        End = DateTime.Now,
                        Device = device
                    };
                    Db.Session.Add(session);

                    Db.SaveChanges();
                }
            }

            Dialog dialog;
            DialogPayload payload = new DialogPayload(instance.Code, HttpContext.Session);            

            if (formPosted)
            {
                payload.FormSent = true;

                foreach (string key in Request.Form.Keys)
                {                    
                    if (key.StartsWith("control_")) {
                        payload.ControlValues.Add(key.Substring(8), Request.Form[key]);
                    }
                }

                payload.ControlFiles = Request.Form.Files;
            }            

            try
            {                             
                dialog = dialogService.GetCurrentDialog(HttpContext.Session.GetString("sys_current_dialog"));
                IAction dialogAction = new ScanApp.Models.Dialog.Action.DialogAction(dialogService)
                {
                    Dialog = dialog.Id
                };

                DialogProcessor processor = new DialogProcessor(dialog, dialogAction);

                dialog = await processor.ProcessDialog(payload);

                if (session != null) {
                    session.End = DateTime.Now;
                }

                if (instance.LogSessionDetails) {
                    Log log = new Log
                    {
                        DateTime = session.End,
                        Session = session,
                        Dialog = dialog.Id,
                        Payload = JsonConvert.SerializeObject(payload.ControlValues)
                    };
                    Db.Log.Add(log);
                }

                Db.SaveChanges();
            } catch (Exception e) {
                Error error = new Error
                {
                    DateTime = DateTime.Now,
                    Session = session,
                    Message = e.Message,
                    StackTrace = e.StackTrace
                };
                Db.Errors.Add(error);

                session.End = error.DateTime;

                Db.SaveChanges();

                HttpContext.Session.Clear();                                              

                Dialog dialog2 = dialogService.GetCurrentDialog();
                IAction dialogAction = new ScanApp.Models.Dialog.Action.DialogAction(dialogService)
                {
                    Dialog = dialog2.Id
                };

                DialogProcessor processor = new DialogProcessor(dialog2, dialogAction);
                dialog = await processor.ProcessDialog(new DialogPayload(instance.Code));                         
            }

            HttpContext.Session.SetString("sys_current_dialog", dialog.Id);

            ViewData["ConfigurationCSS"] = dialogService.CustomCss;
            ViewData["DialogCSS"] = dialog.CustomCSS;
            ViewData["InstanceCSS"] = instance.CustomCSS;
            ViewData["CompatibilityModeWindowsCE"] = instance.CompatibilityModeWindowsCE;
            ViewData["AutomaticRefreshSeconds"] = dialog.AutomaticRefreshSeconds;
            ViewData["DeviceFingerprint"] = HttpContext.Session.GetString("scanapp_device_fingerprint");
            
            ViewData["DeviceTypeCSS"] = null;
            if (device != null && device.Type != null) {
                ViewData["DeviceTypeCSS"] = device.Type.CustomCSS;
            }

            return View(dialog);*/
        }
    }   
}