angular.module("Home")
    .factory("mapsService",
        function ($http, baseService) {

            var mapsAPI = {};

            mapsAPI.getMaps = function () {
                return baseService.get('api/maps');
            }

            mapsAPI.addMap = function (mapinfo) {
                return baseService.post('api/maps', mapinfo);
            }

            mapsAPI.deleteMap = function (id) {
                return baseService.delete('api/maps/' + id);
            }

            mapsAPI.editMap = function (id, mapinfo) {
                return baseService.put('api/maps/' + id, mapinfo);
            }


            return mapsAPI;
        });