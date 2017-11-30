//sample in creating object in angularjs
angular.module('otherApp')
.factory('JobStatusViewModelObject', function () {
    var object = function Property(ID, Description) {
        this.ID = ID;
        this.Description = Description;
    }
    return object;
});