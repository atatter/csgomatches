angular.module("Home")
    .factory("commentService",
        function ($http, baseService) {
            console.log("MatchesService initialized");

            var commentAPI = {};

            commentAPI.deleteComment = function (commentid) {
                return baseService.delete('api/comments/' + commentid);
            }

            commentAPI.getComments = function (id) {
                return baseService.get('api/comments/' + id);
            }

            commentAPI.addComment = function (commentinfo) {
                return baseService.post('api/comments', commentinfo);
            }

            return commentAPI;
        });