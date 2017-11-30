//sample in creating object in angularjs
angular.module('otherApp')
.factory('IconNavigationObject', function () {
    var object = function Property(nlabel, nicon, npath) {
        this.label = nlabel;
        this.icon = nicon;
        this.path = npath;
    }
    return object;
});