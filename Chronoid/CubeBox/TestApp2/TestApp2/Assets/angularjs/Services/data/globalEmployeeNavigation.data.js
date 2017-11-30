angular.module('otherApp')
.factory('GlobalizationEmployeeNavigation', ['$location', 'ButtonObject', function ($location, ButtonObject) {
    var navigate = function (value) {
        $location.path(value);
    }
    var Globalization = {
        navigation:[
                    new ButtonObject("mdi-4x mdi-editor-format-list-bulleted", "Employees", "/Employee", navigate),
                    new ButtonObject("mdi-4x mdi-content-add-box", "Add Employee", "/Employee/AddUsers", navigate),
                    new ButtonObject("mdi-4x mdi-action-alarm-add", "Setup Schedule", "/Employee/Schedule", navigate),
                    new ButtonObject("mdi-4x mdi-editor-insert-drive-file", "Report", "/Employee/Report", navigate),
                    new ButtonObject("mdi-4x mdi-editor-insert-invitation", "Holidays", "/Employee/Holiday", navigate),
                    new ButtonObject("mdi-4x mdi-content-backspace", "Back", "/", navigate)
        ]
    };
    return Globalization;
}]);