'use strict';

angular.module('widget.webcam1', [])
    .directive('webcam1', ['$http',
        '$location', '$interval', '$window', 'CustomTimout','Base64ToBlob',
        function ($http, $location, $interval, $window, CustomTimout, Base64ToBlob) {
            function preFn(scope, element, attr) {
            }
            /* Do the directive's logic here */
            function postFn(scope, element, attr) {
                var _video = null, patData = null;
                scope.controller = scope.controller == null ? {} : scope.controller;

                scope.patOpts = { x: 0, y: 0, w: 25, h: 25 };
                // Setup a channel to receive a video property
                // with a reference to the video element
                // See the HTML binding in main.html
                scope.channel = {};
                scope.webcamError = false;
                scope.onError = function (err) {
                    scope.$apply(
                        function () {
                            scope.webcamError = err;
                        }
                    );
                };
                scope.onSuccess = function () {
                    // The video element contains the captured camera data
                    _video = scope.channel.video;
                    scope.$apply(function () {
                        scope.patOpts.w = _video.width;
                        scope.patOpts.h = _video.height;
                    });
                };

                scope.onStream = function (stream) {
                    // You could do something manually with the stream.
                };
                scope.controller.snap = function () {
                    if (_video) {
                        var patCanvas = document.querySelector('#snapshot');
                        if (!patCanvas) return;

                        patCanvas.width = _video.width;
                        patCanvas.height = _video.height;
                        var ctxPat = patCanvas.getContext('2d');

                        var idata = getVideoData(scope.patOpts.x, scope.patOpts.y, scope.patOpts.w, scope.patOpts.h);
                        ctxPat.putImageData(idata, 0, 0);
                        sendSnapshotToServer(patCanvas.toDataURL());
                        patData = idata;
                    }
                };
                /**
                 * Redirect the browser to the URL given.
                 * Used to download the image by passing a dataURL string
                 */
                scope.downloadSnapshot = function downloadSnapshot(dataURL) {
                    window.location.href = dataURL;
                };
                // this is how to view image in an canvas
                var getVideoData = function getVideoData(x, y, w, h) {
                    var hiddenCanvas = document.createElement('canvas');
                    hiddenCanvas.width = _video.width;
                    hiddenCanvas.height = _video.height;
                    var ctx = hiddenCanvas.getContext('2d');
                    ctx.drawImage(_video, 0, 0, _video.width, _video.height);
                    return ctx.getImageData(x, y, w, h);
                };
                /**
                 * This function could be used to send the image data
                 * to a backend server that expects base64 encoded images.
                 *
                 * In this example, we simply store it in the scope for display.
                 */
                var sendSnapshotToServer = function sendSnapshotToServer(imgBase64) {
                    CustomTimout(function () {
                        scope.captureEvent(imgBase64);
                    }, 100);


                    //converts image64 to blob
                    //Base64ToBlob(imgBase64, function (blob) {
                    //    scope.imageData = blob;
                    //    CustomTimout(function () {
                    //        scope.captureEvent(blob);
                    //    }, 100);
                    //});
                };
            }
            return {
                restrict: 'E',
                transclude:true,
                scope: {
                    controller:'=',
                    imageData: '=',
                    captureEvent:'=',
                },
                replace: true,
                templateUrl: 'Assets/angularjs/components/Widgets/WebcamWidget1/webcam1.widget.html',
                compile: function(scope, element, attr) {
                    return {
                        pre: preFn,
                        post: postFn
                    }
                }
            };
        }
    ]);