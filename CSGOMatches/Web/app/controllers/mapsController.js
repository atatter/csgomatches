angular.module("Home")
    .controller("mapsController",
        function ($scope, $location, mapsService) {
            console.log("MapsController init");

            if (!$scope.auth) {
                $location.path("/");
            }

            $scope.c = true;

            var loadMaps = function() {
                mapsService.getMaps().success(function(resp) {
                    $scope.maps = resp;
                });
            }

            $scope.add = function () {
                var mapinfo = {
                    MapName: $scope.mapName
                }
                mapsService.addMap(mapinfo).success(function () {
                    loadMaps();
                });
                $scope.mapName = undefined;
                $scope.mapId = undefined;
            }

            $scope.delete = function (id) {
                mapsService.deleteMap(id).success(function () {
                    loadMaps();
                });
            }

            $scope.addToEdit = function (map) {
                $scope.c = false;
                $scope.mapName = map.mapName;
                $scope.mapId = map.mapId;
            }

            $scope.edit = function () {
                var mapinfo = {
                    MapName: $scope.mapName
                }
                mapsService.editMap($scope.mapId, mapinfo).success(function () {
                    loadMaps();
                });
                $scope.mapName = undefined;
                $scope.mapId = undefined;
                $scope.c = true;
            }

            loadMaps();

        });