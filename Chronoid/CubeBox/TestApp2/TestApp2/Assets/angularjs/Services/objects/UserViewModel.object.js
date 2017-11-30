//sample in creating object in angularjs
angular.module('otherApp')
.factory('UserViewModelObject', [function () {
    var object = function Property(ID, Code, FirstName, LastName, MiddleName,
                                   ExtensionName, Gender, MaritalStatus, Nationality,
                                   Religion,Address, Birthday, Jobtitle, JobStatus, Email, Role,ContactPerson,
                                   ContactNumber, profileImage, Company, aspNetUser) {
        this.ID = ID;
        this.Code = Code;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.MiddleName = MiddleName;
        this.ExtensionName = ExtensionName;
        this.Gender = Gender == '' || Gender == undefined ? 'Male' : Gender;
        console.log(MaritalStatus);
        this.MaritalStatus = MaritalStatus == '' || MaritalStatus == undefined ? 'Single' : MaritalStatus;
        this.Nationality = Nationality;
        this.Religion = Religion;
        this.Address = Address;
        this.Birthday = Birthday;
        console.log("Initialized");
        this.Jobtitle = Jobtitle == undefined || Jobtitle=='' ? { ID: 0, Description: '' } : Jobtitle;
        this.JobStatus = JobStatus;
        this.Email = Email;
        this.Role = Role;
        this.ContactPerson = ContactPerson;
        this.ContactNumber = ContactNumber;
        this.profileImage = profileImage;
        this.Company = Company;
        this.aspNetUser = aspNetUser;
    }
    return object;
}]);