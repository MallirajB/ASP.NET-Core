using EmployeeForm.Core.IRepository;
using EmployeeForm.Core.Model;
using EmployeeForm.Entity;
using System.Runtime;

namespace EmployeeForm.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeDetailsContext entity;
        public EmployeeRepository(EmployeeDetailsContext context)
        {
            entity = context;
        }
        #region ValueAssign
        public EmployeeDetails EditMethod(int employeeId)
        {
                EmployeeDetails EmployeeModel = new EmployeeDetails();
                var data = entity.EmployeeInfo.Where(x => x.Employee_ID == employeeId).SingleOrDefault();
                EmployeeModel.EmployeeId = data.Employee_ID;
                EmployeeModel.FirstName = data.First_Name;
                EmployeeModel.LastName = data.Last_Name;
                EmployeeModel.EmployeeAge = data.Employee_Age;
                var value = data.LocationId;
                var section = entity.EmployeeLocation.Where(x => x.LocationId == value).SingleOrDefault();
                EmployeeModel.WorkLocation = section.Employee_Work_Location;
                EmployeeModel.LocationId = data.LocationId;
                EmployeeModel.EmployeeAddress = data.Employee_Address;
                EmployeeModel.ContactNumber = data.Contact_Number;
                EmployeeModel.EmployeeExperience = data.Employee_Experience;
                EmployeeModel.DateStr = data.Date_of_Joining.ToString("yyyy-MM-dd");
                EmployeeModel.CreatePassword = data.Create_Password;
                EmployeeModel.ConfirmPassword = data.Confirm_Password;
                return EmployeeModel;
        }
        #endregion

        #region CreateMethod
        public void CreateMethod(EmployeeDetails employeeDetails)
        {
            if (employeeDetails != null)
            {
                if (employeeDetails.EmployeeId == 0)
                {
                    //database model
                    EmployeeInfo info = new EmployeeInfo();
                    info.First_Name = employeeDetails.FirstName;
                    info.Last_Name = employeeDetails.LastName;
                    info.Employee_Age = employeeDetails.EmployeeAge;
                    info.Employee_Experience = employeeDetails.EmployeeExperience;
                    info.Employee_Address = employeeDetails.EmployeeAddress;
                    info.LocationId = employeeDetails.LocationId;
                    info.Contact_Number = employeeDetails.ContactNumber;
                    info.Date_of_Joining = DateTime.Parse(employeeDetails.DateStr);
                    info.Create_Password = employeeDetails.CreatePassword;
                    info.Confirm_Password = employeeDetails.ConfirmPassword;
                    entity.Add(info);
                    entity.SaveChanges();
                }
                else
                {
                    var value = entity.EmployeeInfo.Where(x => x.Employee_ID == employeeDetails.EmployeeId).SingleOrDefault();
                    if (value != null)
                    {
                        value.First_Name = employeeDetails.FirstName;
                        value.Last_Name = employeeDetails.LastName;
                        value.Employee_Age = employeeDetails.EmployeeAge;
                        value.Employee_Experience = employeeDetails.EmployeeExperience;
                        value.Employee_Address = employeeDetails.EmployeeAddress;
                        value.LocationId = employeeDetails.LocationId;
                        value.Contact_Number = employeeDetails.ContactNumber;
                        value.Date_of_Joining = DateTime.Parse(employeeDetails.DateStr);
                        value.Create_Password = employeeDetails.CreatePassword;
                        value.Confirm_Password = employeeDetails.ConfirmPassword;
                        value.Updated_Time_Stamp = DateTime.Now;
                        entity.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region ListMethod
        public List<EmployeeDetails> ListMethod()
        {
            List<EmployeeDetails> model = new List<EmployeeDetails>();
            var data = entity.EmployeeInfo.Where(x => x.Is_Deleted == false).ToList();

            foreach (var item in data)
            {
                EmployeeDetails employeeDetails = new EmployeeDetails();
                employeeDetails.EmployeeId = item.Employee_ID;
                employeeDetails.FirstName = item.First_Name;
                employeeDetails.LastName = item.Last_Name;
                employeeDetails.EmployeeAge = item.Employee_Age;
                employeeDetails.EmployeeAddress = item.Employee_Address;
                var value = item.LocationId;
                var section = entity.EmployeeLocation.Where(x => x.LocationId == value).SingleOrDefault();
                employeeDetails.WorkLocation = section.Employee_Work_Location;
                employeeDetails.LocationId = item.LocationId;
                employeeDetails.ContactNumber = item.Contact_Number;
                employeeDetails.EmployeeExperience = item.Employee_Experience;
                employeeDetails.DateStr = item.Date_of_Joining.ToString("yyyy/MM/dd");
                employeeDetails.CreatePassword = item.Create_Password;
                employeeDetails.ConfirmPassword = item.Confirm_Password;
                model.Add(employeeDetails);
            }
            return model;
        }
        #endregion

        #region DeleteMethod
        public void DeleteMethod(int employeeId)
        {
            var value = entity.EmployeeInfo.Where(x => x.Employee_ID == employeeId).SingleOrDefault();
            if (value != null)
            {
                value.Is_Deleted = true;
                entity.SaveChanges();
            }
        }
        #endregion

        #region SearchMethod
        public List<EmployeeDetails> SearchMethod(string name)
        {

            List<EmployeeDetails> model = new List<EmployeeDetails>();
            var data = entity.EmployeeInfo.Where(x => x.First_Name.Contains(name) && x.Is_Deleted == false).ToList();
            if (name != null)
            {
                foreach (var item in data)
                {
                    EmployeeDetails employeeDetails = new EmployeeDetails();
                    employeeDetails.EmployeeId = item.Employee_ID;
                    employeeDetails.FirstName = item.First_Name;
                    employeeDetails.LastName = item.Last_Name;
                    employeeDetails.EmployeeAge = item.Employee_Age;
                    employeeDetails.LocationId = item.LocationId;
                    employeeDetails.EmployeeAddress = item.Employee_Address;
                    employeeDetails.ContactNumber = item.Contact_Number;
                    employeeDetails.EmployeeExperience = item.Employee_Experience;
                    employeeDetails.DateStr = item.Date_of_Joining.ToString("yyyy/MM/dd");
                    employeeDetails.CreatePassword = item.Create_Password;
                    employeeDetails.ConfirmPassword = item.Confirm_Password;
                    model.Add(employeeDetails);

                }
            }
            return model;

        }
        #endregion

        #region Dropdownassign
        public List<Location> GetDropdown()
        {
            List<Location> City = new List<Location>();
            using (EmployeeDetailsContext Entities = new EmployeeDetailsContext())
            {
                var ListDb = Entities.EmployeeLocation.Where(x => x.Is_Deleted == false).ToList();
                if (ListDb != null)
                {
                    foreach (var List in ListDb)
                    {
                        Location Place = new Location();
                        Place.LocationId = List.LocationId;
                        Place.WorkLocation = List.Employee_Work_Location;
                        City.Add(Place);
                    }
                }
            }
            return City;
        }
        #endregion
    }
}

