angular.module('modules.Company', [])
.config(['$routeProvider',
         function ($routeProvider) {
             /* Handle route on location path is '/' */
             $routeProvider.when('/Company', {
                 templateUrl: '/Assets/angularjs/Pages/Admin/routes/company/company.page.html',
                 controller: 'CompanyCtrl'
             });
         }
]);