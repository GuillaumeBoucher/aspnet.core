using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using UsersMgmt.Models;
using cmdb_dal;
using cmdb_model;
using cmdb_model.contact;


namespace UsersMgmt.Controllers.Contacts
{
    public class UserController : Controller
    {

        private static cmdb_dal.DbContext context = new cmdb_dal.DbContext("c:/dev/cmdb/webs.ui/UsersMgmt/Data/person.db");


        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DataTableLoad(DataTableAjaxPostModel model)
        {
            // action inside a standard controller
            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            var result = YourCustomSearchFunc(model, out filteredResultsCount, out totalResultsCount);


            return Json(new
            {
                // this is what datatables wants sending back
                draw = model.draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
            });


        }

       
        private List<Person> YourCustomSearchFunc(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount)
        {
            var searchBy = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "";
            bool sortDir = true;

            if (model.order != null)
            {
                // in this example we just default sort on the 1st column
                sortBy = model.columns[model.order[0].column].data;
                sortDir = model.order[0].dir.ToLower() == "asc";
            }

            // search the dbase taking into consideration table sorting and paging
            var result = GetDataFromDbase(searchBy, take, skip, sortBy, sortDir, out filteredResultsCount, out totalResultsCount);

            if (result == null)
            {
                // empty collection...
                return new List<Person>();
            }
            return result;
        }

        private List<Person> GetDataFromDbase(string searchBy, int take, int skip, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount)
        {
            var result = new List<Person>();

            List<Person> ListOfCitations = context.GetData<Person>();

            if (ListOfCitations.Count() == 0)
            {

                Person DefautPerson = new Person();

                DefautPerson.nom = "BOUCHER";
                DefautPerson.prenom = "Guillaume";                
                DefautPerson.email = "guillaume.boucher@csa.fr";

                ListOfCitations.Add(DefautPerson);
                
                context.Upsert<Person>(ListOfCitations);
            }

            if (String.IsNullOrEmpty(searchBy))
            {
                if (take == -1)
                {
                    result = ListOfCitations.ToList();
                }
                else
                {
                    result = ListOfCitations.Skip(skip).Take(take).ToList();
                }
            }
            else
            {
                if (take == -1)
                {
                    result = ListOfCitations.Where(x => x.nom.ToLower().Contains(searchBy) || x.prenom.ToLower().Contains(searchBy) || x.email.ToLower().Contains(searchBy)).ToList();
                }
                else
                {
                    result = ListOfCitations.Where(x => x.nom.ToLower().Contains(searchBy) || x.prenom.ToLower().Contains(searchBy) || x.email.ToLower().Contains(searchBy)).Skip(skip).Take(take).ToList();
                }
            }


            if (String.IsNullOrEmpty(sortBy))
            {
                // if we have an empty search then just order the results by Id ascending
                sortBy = "Id";
                sortDir = true;
            }


            if (!string.IsNullOrEmpty(sortBy) && result != null && result.Count > 0)
            {

                Type t = result[0].GetType();

                if (sortDir) // Ascending
                {

                    result = result.OrderBy(
                        a => t.InvokeMember(
                            sortBy
                            , System.Reflection.BindingFlags.GetProperty
                            , null
                            , a
                            , null
                        )
                    ).ToList();
                }
                else
                {
                    result = result.OrderByDescending(
                        a => t.InvokeMember(
                            sortBy
                            , System.Reflection.BindingFlags.GetProperty
                            , null
                            , a
                            , null
                        )
                    ).ToList();
                }
            }



            filteredResultsCount = ListOfCitations.Count();
            totalResultsCount = ListOfCitations.Count();


            return result;
        }

        public JsonResult DataTableChange()
        {

            JsonResult _ret = Json(new { String.Empty });

            IFormCollection formData = HttpContext.Request.Form;

            string action = formData["action"];

            switch (action)
            {
                case "create":
                    {
                        string firstname = formData["data[0][firstname]"];
                        string lastname = formData["data[0][lastname]"];
                        string email = formData["data[0][email]"];
                        //todo check if  already exit ? 
                        YourCustomSearchClass newObj = new YourCustomSearchClass();
                        newObj.firstname = firstname;
                        newObj.lastname = lastname;
                        newObj.email = email;
                        //save to DB                        
                        int NbSaveElement = context.Insert<YourCustomSearchClass>(newObj);
                        //newObj.Id = id;

                        _ret = Json(new
                        {
                            data = newObj
                        });

                        break;
                    }
                case "edit":
                    {
                        //Read ID
                        List<string> Keys = formData.Keys.ToList();
                        string id_data = Keys[1];
                        string id_data_clean = id_data.Substring(5, id_data.Length - 5);
                        string RealId = id_data_clean.Split(']')[0];

                        //Read new Value 
                        string firstname = formData["data[" + RealId + "][firstname]"];
                        string lastname = formData["data[" + RealId + "][lastname]"];
                        string email = formData["data[" + RealId + "][email]"];

                        //updateToDb
                        YourCustomSearchClass _updateObj = new YourCustomSearchClass();
                        _updateObj.Id = Convert.ToInt32(RealId);
                        _updateObj.firstname = firstname;
                        _updateObj.lastname = lastname;
                        _updateObj.email = email;

                        context.Update<YourCustomSearchClass>(_updateObj);

                        _ret = Json(new
                        {
                            data = _updateObj
                        });


                        break;
                    }
                case "remove":
                    {
                        List<string> Keys = formData.Keys.ToList();

                        List<string> IDKeys = new List<string>();
                        foreach (string s in Keys)
                        {
                            if (s.Contains("id"))
                            {
                                IDKeys.Add(s);
                            }

                        }

                        foreach (string id_data in IDKeys)
                        {
                            string id_data_clean = id_data.Substring(5, id_data.Length - 5);
                            string RealId = id_data_clean.Split(']')[0];

                            //delete dans la base de données
                            int idToDelete = Convert.ToInt32(RealId);
                            context.Delete<YourCustomSearchClass>(idToDelete);
                        }
                        break;
                    }
            }

            return _ret;
        }

        private List<T> GetRequestForm<T>(IFormCollection formData)
        {
            List<T> _ret = new List<T>();

            System.Reflection.PropertyInfo[] props = typeof(T).GetProperties();

            // create an instance of that type
            object instance = Activator.CreateInstance(typeof(T));

            // Get a property on the type that is stored in the 
            // property string
            //PropertyInfo prop = type.GetProperty(property);

            // Set the value of the given property on the given instance
            //prop.SetValue(instance, value, null);


            List<string> Keys = formData.Keys.ToList();
            int NbKeys = Keys.Count();

            int propIndice = 0;
            for (int i = 0; i < NbKeys; i = i + 10)
            {
                foreach (var prop in props)
                {
                    string Key = Keys[propIndice + i];

                    object value = new object();
                    switch (prop.PropertyType.Name)
                    {
                        case "Int32":
                            {
                                value = Convert.ToInt32(formData[Key]);
                                break;
                            }
                        case "String":
                            {
                                value = formData[Key].ToString();
                                break;
                            }
                    }
                    prop.SetValue(instance, value, null);
                    propIndice++;
                }
                _ret.Add((T)instance);
            }



            return _ret;

        }

        public ActionResult ItemSelected()
        {

            //List<Person> data = this.GetRequestForm<Person>(HttpContext.Request.Form);

            //IFormCollection formData = HttpContext.Request.Form;

            //var a = formData["undefined"];
            //string u = formData["username"];
            //string p = formData["password"];

            //int i = 1;

            return View("Index");
        }


        //// GET: User/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: User/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: User/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: User/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: User/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}