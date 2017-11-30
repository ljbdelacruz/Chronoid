'use strict';

//this app is for login page
angular.element(document)
    .ready(function () {
        angular.bootstrap(document, ['ngStarterKit']);
    });
angular.module('ngStarterKit', [
            'ngRoute',
            /*route modules*/
            'modules.Main',
            'modules.Settings',
            'modules.Employee',
                /*Employee Sub Routes*/
                'modules.AddUsers',
                'modules.EditUsers',
                'modules.Schedule',
                    'modules.GroupSchedule',
                    'modules.AddShift',
                'modules.Report',
                'modules.Holiday',
                /*Sub Directives*/
                'directives.common.peopleNavbar',
            'modules.PublicView',
            'modules.Break',
            /*containers*/
            'directives.cardContainer1',
            'directives.cardContainer2',
            'directives.cardContainer3',
            'directives.borderContainer1',
            'directives.borderContainer1',
            /*Widgets*/
            'directives.imageUploader1',
            'directives.badge',
            /*data tables*/
            'directives.table1',
            'directives.burningIcon1',
            /*UserInputs*/
            'directives.button1',
            'directives.button2',
            'directives.textBox3',
            'directives.textBox4',
            'directives.selection1',
            'directives.checkbox1',
            'directives.timePicker1',
            'directives.switch1',
            /*Modals*/
            'directives.modal1',
            'directives.modal2',
            'directives.modal3',
            'directives.modal4',
            /*Drop Down*/
            'directives.dropDown3',
            /*3rd Party Directives*/
            'webcam',
            'otherApp',
])
.config(['$routeProvider',
                 function ($routeProvider) {
                     $routeProvider.otherwise({ redirectTo: '/' });
                 }
]);