(function () {

    "use strict";

    angular
        .module("portfolio")
        .controller("projectListController",
                    ["projectResource",
                        ProjectListController]);

    function ProjectListController(projectResource) {
        var vm = this;

        projectResource.get(function (data) {
            vm.projects = data.results;
            console.log(data);
        });
    }


})();