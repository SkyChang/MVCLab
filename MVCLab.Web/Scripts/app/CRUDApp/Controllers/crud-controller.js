angular.module('crudApp.controllers.crud',
    [
        'crudApp.services.customerServices'
    ])
.controller('crud', function ($scope, customerServices) {

    $scope.cust = {};

    $scope.custs = customerServices.query();

    $scope.add = function () {
        customerServices.create($scope.cust, function (data) {
            $scope.custs = customerServices.query();
        });
    }

    $scope.edit = function (id) {
        $scope.cust = customerServices.queryByID({ id: id }, function (data) {
            $scope.cust = data;
        });

    }

    $scope.update = function () {
        customerServices.update( {id:$scope.cust.ID },$scope.cust, function (data) {
            $scope.custs = customerServices.query();
        });
    }

    $scope.del = function (id) {
        customerServices.del({ id: id }, function (data) {
            $scope.custs = customerServices.query();
        });

    }
});