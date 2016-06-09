angular.module("Authentication")
    .factory("headerService",
        function ($http, baseService) {

            var headerAPI = {};

            headerAPI.getAuth = function () {
                baseService.get('api/Account/UserInfo').then(function successCallback(response) {
                            console.log("has auth");
                            return true;
                        },
                        function errorCallback(response) {
                            console.log("no auth");
                            return false;
                        });             
            }

            return headerAPI;
        });