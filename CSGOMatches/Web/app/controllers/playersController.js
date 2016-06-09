angular.module("Home")
    .controller("playersController",
        function ($scope, $location, playersService) {
            console.log("PlayersController init");

            var loadPlayers = function() {
                playersService.getPlayers().success(function(resp) {
                    $scope.players = resp;
                });
            }

            loadPlayers();
        });