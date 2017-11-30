
angular.module('otherApp')
.factory('Selection1Object', function () {
    var object = function Property(id, description, value) {
        this.id = id;
        this.description = description;
        this.value = value;
    }
    return object;
});