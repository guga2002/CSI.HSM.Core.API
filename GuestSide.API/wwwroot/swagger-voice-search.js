window.addEventListener("load", function () {
    const darkModeButton = document.createElement('button');
    darkModeButton.innerHTML = '🌙 Dark Mode';
    darkModeButton.style.position = 'fixed';
    darkModeButton.style.top = '20px';
    darkModeButton.style.right = '20px';
    darkModeButton.style.padding = '12px 20px';
    darkModeButton.style.fontSize = '16px';
    darkModeButton.style.fontWeight = 'bold';
    darkModeButton.style.borderRadius = '30px';
    darkModeButton.style.backgroundColor = '#4CAF50'; 
    darkModeButton.style.color = '#ffffff'; 
    darkModeButton.style.border = 'none';
    darkModeButton.style.cursor = 'pointer';
    darkModeButton.style.zIndex = '1000';
    darkModeButton.style.transition = 'background-color 0.3s, transform 0.3s';

    darkModeButton.addEventListener('mouseenter', function () {
        darkModeButton.style.backgroundColor = '#45a049';
        darkModeButton.style.transform = 'scale(1.1)';
    });
    darkModeButton.addEventListener('mouseleave', function () {
        darkModeButton.style.backgroundColor = '#4CAF50';
        darkModeButton.style.transform = 'scale(1)';
    });

    document.body.appendChild(darkModeButton);

    const isDarkMode = localStorage.getItem('darkMode') === 'true';

    function applyDarkMode() {
        
        document.body.style.transition = 'background-color 0.5s, color 0.5s';  
        document.body.style.backgroundColor = '#A9A9A9';  
        document.body.style.color = '#008000';  

   
        const elements = document.querySelectorAll('.swagger-ui, .swagger-ui .topbar, .swagger-ui .info, .swagger-ui .btn, .swagger-ui .btn:hover, .swagger-ui .description, .swagger-ui .response-col-description, .swagger-ui .model-title, .swagger-ui .section .title, .swagger-ui .filter-input, .swagger-ui .operation-tag, .swagger-ui .model-detail, .swagger-ui .operation-description');
        elements.forEach(element => {
            element.style.backgroundColor = '';  
            element.style.color = '#008000';  
            element.style.borderColor = '#008000';  
        });

  
        const controllerNames = document.querySelectorAll('.swagger-ui .opblock-tag .opblock-tag-no-desc span, .swagger-ui .opblock-tag a');
        controllerNames.forEach(name => {
            name.style.color = '#008000'; 
        });

        const apiEndpointRoutes = document.querySelectorAll('.swagger-ui .opblock-summary-path');
        apiEndpointRoutes.forEach(route => {
            route.style.color ='#000000' 
        });


        const descriptions = document.querySelectorAll('.swagger-ui .parameter__description, .swagger-ui .response-col-description, .swagger-ui .operation-description');
        descriptions.forEach(description => {
            description.style.color = ''; 
        });

        darkModeButton.innerHTML = '🌞 Light Mode';
    }

    function applyLightMode() {

        document.body.style.transition = 'background-color 0.5s, color 0.5s';  // Smooth transition
        document.body.style.backgroundColor = '';  
        document.body.style.color = '';  

        const elements = document.querySelectorAll('.swagger-ui, .swagger-ui .topbar, .swagger-ui .info, .swagger-ui .btn, .swagger-ui .btn:hover, .swagger-ui .description, .swagger-ui .response-col-description, .swagger-ui .model-title, .swagger-ui .section .title, .swagger-ui .filter-input, .swagger-ui .operation-tag, .swagger-ui .model-detail, .swagger-ui .operation-description');
        elements.forEach(element => {
            element.style.backgroundColor = '';  
            element.style.color = '';  
            element.style.borderColor = ''; 
        });

        const controllerNames = document.querySelectorAll('.swagger-ui .opblock-tag .opblock-tag-no-desc span, .swagger-ui .opblock-tag a');
        controllerNames.forEach(name => {
            name.style.color = ''; 
        });

        const apiEndpointRoutes = document.querySelectorAll('.swagger-ui .opblock-summary-path');
        apiEndpointRoutes.forEach(route => {
            route.style.color = '';  
        });

        const descriptions = document.querySelectorAll('.swagger-ui .parameter__description, .swagger-ui .response-col-description, .swagger-ui .operation-description');
        descriptions.forEach(description => {
            description.style.color = ''; 
        });

        darkModeButton.innerHTML = '🌙 Dark Mode';
    }

    if (isDarkMode) {
        applyDarkMode();
    } else {
        applyLightMode();
    }

    darkModeButton.addEventListener('click', function () {
        const isCurrentlyDarkMode = localStorage.getItem('darkMode') === 'true';
        if (isCurrentlyDarkMode) {
            applyLightMode();
            localStorage.setItem('darkMode', 'false');
        } else {
            applyDarkMode();
            localStorage.setItem('darkMode', 'true');
        }
    });
});




