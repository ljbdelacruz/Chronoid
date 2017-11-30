//sample in creating object in angularjs
angular.module('otherApp')
.factory('ButtonObject', function () {
    var object = function Property(icon, label, value, event) {
        this.icon = icon;
        this.label=label;
        this.value = value;
        this.event = event;
    }
    return object;
});