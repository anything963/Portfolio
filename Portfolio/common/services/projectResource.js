(function () {

    "use strict";

    angular.module("common.services")
        .factory("projectResource", 
                    ["$resource", projectResource]);

    function projectResource($resource) {
        return $resource("/v1/api/userportfolio/1/project/:projectId", { projectId: '@projectId' },
            {
                update: { method: 'PUT' },

            }
        );

 //       $resource('/user/:userId/card/:cardId',
 //{ userId: 123, cardId: '@id' }, {
 //    charge: { method: 'POST', params: { charge: true } }
        //});


    }
})();