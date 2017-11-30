//sample in creating object in angularjs
angular.module('otherApp')
.factory('CompanyViewModelObject', function () {
    var object = function Property(ID, Name, createdAt) {
        this.ID = ID;
        this.Name = Name;
        this.createdAt = createdAt;
    }
    return object;
});