angular.module('otherApp')
.factory('GlobalTimeZone', [function () {
    var Globalization = {
        list: [{value:'PH', description:'Philippines'}, {value:'CT', description:'Central Timezone'}]
    };
    return Globalization;
}]);