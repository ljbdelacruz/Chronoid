'use strict';

/* Create module for navbar directive */
angular.module('directives.imageUploader1', [])
    .directive('imageUploader1', ['$http',
        '$location', 'CustomTimout',
        function ($http, $location, CustomTimout) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                scope.OnChange = function () {
                    var reader = new FileReader();
                    reader.readAsDataURL($('#uimage')[0].files[0]);
                    CustomTimout(function () {
                        $('#imgDisp').attr('src', reader.result);
                        scope.file = reader.result;
                    }, 100);

                }
            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    file:'=',
                    defaultTemplate:'=',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Widgets/ImageUploader/ImageUploader.widget.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);