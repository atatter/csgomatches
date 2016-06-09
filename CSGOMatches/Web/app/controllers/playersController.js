angular.module("Home")
    .controller("playersController",
        function ($scope, $location, playersService) {
            if (!$scope.auth) {
                $location.path("/");
            }
            console.log("PlayersController init");
            $scope.c = true;

            var loadPlayers = function() {
                playersService.getPlayers().success(function(resp) {
                    $scope.players = resp;
                });
            }

            $scope.add = function () {
                var playerinfo = {
                    Nick: $scope.playerName
                }
                playersService.addPlayer(playerinfo).success(function() {
                    loadPlayers();
                });
                $scope.playerName = undefined;
                $scope.playerId = undefined;
            }

            $scope.delete = function(id) {
                playersService.deletePlayer(id).success(function() {
                    loadPlayers();
                });
            }

            $scope.addToEdit = function(player) {
                $scope.c = false;
                $scope.playerName = player.nick;
                $scope.playerId = player.playerId;
            }

            $scope.edit = function() {
                var playerinfo = {
                    Nick: $scope.playerName
                }
                playersService.editPlayer($scope.playerId, playerinfo).success(function() {
                    loadPlayers();
                });
                $scope.playerName = undefined;
                $scope.playerId = undefined;
                $scope.c = true;
            }

            loadPlayers();
        });