//sample in creating object in angularjs
angular.module('otherApp')
.factory('ModalAlertObject', function () {
    var object=function Property(icon, title, description, succeedEvent, failedEvent, colors, button1, button2) {
        this.icon = icon;
        this.title = title;
        this.description = description;
        this.succeedEvent = succeedEvent;
        this.failedEvent = failedEvent;
        this.colors = colors;
        this.button1=button1;
        this.button2 = button2;
    }
    return object;
});