//sample in creating object in angularjs
angular.module('otherApp')
.factory('AspNetUserViewModelObject', function () {
    var object = function Property(ID, Email, UserName, IsOnline, passwordHash) {
        this.ID = ID;
        this.Email = Email;
        this.UserName = UserName;
        this.IsOnline = IsOnline;
        this.passwordHash = passwordHash;
    }
    return object;
});