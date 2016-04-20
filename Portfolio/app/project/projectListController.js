(function () {

    "use strict";

    angular
        .module("portfolio")
        .controller("projectListController",
                    ["projectResource",
                        ProjectListController]);

    function ProjectListController(projectResource) {
        var vm = this;

        projectResource.query(function (data) {
            vm.projects = data;
            console.log(data);
        });
    }


})();