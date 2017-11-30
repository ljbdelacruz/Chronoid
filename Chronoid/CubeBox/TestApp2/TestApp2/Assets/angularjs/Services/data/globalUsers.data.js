angular.module('otherApp')
.factory('GlobalizationUser', ['UserViewModelObject', function (UserViewModelObject) {
    var Globalization = {
        currentUser: new UserViewModelObject(),
        users: [],
        count:0,
        editUsers: new UserViewModelObject(),
        userInfo: {}
    };
    return Globalization;
}]);