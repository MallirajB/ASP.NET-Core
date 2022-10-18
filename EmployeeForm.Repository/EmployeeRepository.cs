using EmployeeForm.Core.IRepository;
using EmployeeForm.Core.Model;
using EmployeeForm.Entity;

namespace EmployeeForm.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        public EmployeeDetailsContext entity;
        public EmployeeRepository(EmployeeDetailsContext context)
        {
            entity = context;
        }
        #region Assign
        public EmployeeDetails EditMethod(int employeeId)
        {
                EmployeeDetails registrationModel = new EmployeeDetails();
                var data = entity.EmployeeInfo.Where(x => x.Employee_Id == employeeId).SingleOrDefault();
                registrationModel.EmployeeId = data.Employee_Id;
                registrationModel.FirstName = data.First_Name;
                registrationModel.LastName = data.Last_Name;
                registrationModel.EmployeeAge = data.Employee_Age;
                registrationModel.EmployeeWorkLocation = data.Employee_work_Location;
                registrationModel.EmployeeAddress = data.Employee_Address;
                registrationModel.ContactNumber = data.Contact_Number;
                registrationModel.EmployeeExperience = data.Employee_Experience ?? 0;
                registrationModel.DateStr = data.Date_of_Joining.ToString("yyyy-MM-dd");
                registrationModel.CreatePassword = data.Create_Password;
                registrationModel.ConfirmPassword = data.Confirm_Password;
                return registrationModel;
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
                    info.Employee_work_Location = employeeDetails.EmployeeWorkLocation;
                    info.Contact_Number = employeeDetails.ContactNumber;
                    info.Date_of_Joining = DateTime.Parse(employeeDetails.DateStr);
                    info.Create_Password = employeeDetails.CreatePassword;
                    info.Confirm_Password = employeeDetails.ConfirmPassword;
                    entity.Add(info);
                    entity.SaveChanges();
                }
                else
                {
                    var value = entity.EmployeeInfo.Where(x => x.Employee_Id== employeeDetails.EmployeeId).SingleOrDefault();
                    if (value != null)
                    {
                        value.First_Name = employeeDetails.FirstName;
                        value.Last_Name = employeeDetails.LastName;
                        value.Employee_Age= employeeDetails.EmployeeAge;
                        value.Employee_Experience = employeeDetails.EmployeeExperience;
                        value.Employee_Address = employeeDetails.EmployeeAddress;
                        value.Employee_work_Location = employeeDetails.EmployeeWorkLocation;
                        value.Contact_Number = employeeDetails.ContactNumber;
                        value.Date_of_Joining = employeeDetails.DateofJoining;
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
                employeeDetails.EmployeeId = item.Employee_Id;
                employeeDetails.FirstName = item.First_Name;
                employeeDetails.LastName = item.Last_Name;
                employeeDetails.EmployeeAge = item.Employee_Age;
                employeeDetails.EmployeeWorkLocation = item.Employee_work_Location;
                employeeDetails.EmployeeAddress = item.Employee_Address;
                employeeDetails.ContactNumber = item.Contact_Number;
                employeeDetails.EmployeeExperience = item.Employee_Experience??0;
                employeeDetails.DateStr= item.Date_of_Joining.ToString("yyyy/MM/dd");
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
            var value = entity.EmployeeInfo.Where(x => x.Employee_Id == employeeId).SingleOrDefault();
            if (value != null)
            {
                value.Is_Deleted = true;
                entity.SaveChanges();
            }
        }
        #endregion
    }
}

