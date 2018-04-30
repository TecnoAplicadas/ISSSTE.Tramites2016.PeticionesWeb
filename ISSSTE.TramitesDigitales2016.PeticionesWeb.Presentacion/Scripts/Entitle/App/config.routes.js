var Routes = {
    home: {
        url: '/home',
        templateUrl: 'Scripts/Entitle/App/home/index.html'
    },
    notEntitle: {
        url: '/notEntitle',
        templateUrl: 'Scripts/Entitle/App/home/validateNoEntitle.html'
    },
    about: {
    	url: '/about',
    	templateUrl: 'Scripts/Entitle/App/home/requisitos.html'
    },
    quotationMortuaries: {        
        url: '/quotations/mortuaries',
    	templateUrl: 'Scripts/Entitle/App/requests/cotizacion.html'
    },
    quotationPackages: {        
        url: '/quotations/mortuaries/:mortuaryId/packages',
    	templateUrl: 'Scripts/Entitle/App/requests/paquetes.html'
    }
    ,
    quotationProducts: {                
        url: '/quotations/mortuaries/packages/Products',
    	templateUrl: 'Scripts/Entitle/App/requests/cotizacionproductos.html'
    }
    ,
    quotationReview: {
    	url: '/quotations/review/quoteId',
    	templateUrl: 'Scripts/Entitle/App/requests/consulta.html'
    }
    ,
    quotationDetails: {        
        url: '/quotations/details/quoteId',
    	templateUrl: 'Scripts/Entitle/App/requests/detalles.html'
    }
    ,
    quotations: {
    	url: '/requests/quotations',
    	templateUrl: 'Scripts/Entitle/App/requests/miscotizaciones.html'
    }
}