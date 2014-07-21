angular.module('crudApp.services.customerServices', [
    'ngResource'
]).factory('customerServices', function ($resource) {
    return $resource('/api/custs', { action: '@action' }, {
        query: { method: 'GET', isArray: true },
        queryByID: { method: 'GET' },
        create: { method: 'POST' },
        update: { method: 'PUT' },
        del: { method: 'DELETE' }
    });
});