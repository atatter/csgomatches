angular.module("Home")
    .factory("baseService",
        function ($http) {

            var baseAPI = {};

            var baseUrl = 'http://localhost:10742/';

            baseAPI.post = function (url, data) {
                var token = sessionStorage.getItem('accessToken');
                var headers = {};

                if (token) {
                    headers.Authorization = 'Bearer ' + token;
                }

                return $http({
                    method: 'POST',
                    url: baseUrl + url,
                    headers: headers,
                    data: data
                });
            }

            baseAPI.put = function (url, data) {
                var token = sessionStorage.getItem('accessToken');
                var headers = {};

                if (token) {
                    headers.Authorization = 'Bearer ' + token;
                }

                return $http({
                    method: 'PUT',
                    url: baseUrl + url,
                    headers: headers,
                    data: data
                });
            }


            baseAPI.get = function (url) {
                var token = sessionStorage.getItem('accessToken');
                var headers = {};

                if (token) {
                    headers.Authorization = 'Bearer ' + token;
                }

                return $http({
                    method: 'GET',
                    headers: headers,
                    url: baseUrl + url
                });
            }

            baseAPI.delete = function (url) {
                var token = sessionStorage.getItem('accessToken');
                var headers = {};

                if (token) {
                    headers.Authorization = 'Bearer ' + token;
                }

                return $http({
                    method: 'DELETE',
                    headers: headers,
                    url: baseUrl + url
                });
            }

            return baseAPI;
        });