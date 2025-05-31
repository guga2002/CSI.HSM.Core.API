window.addEventListener("load", function () {
    const darkModeButton = document.createElement('button');
    darkModeButton.innerHTML = '🌙 Dark Mode';
    Object.assign(darkModeButton.style, {
        position: 'fixed',
        top: '20px',
        right: '20px',
        padding: '12px 20px',
        fontSize: '16px',
        fontWeight: 'bold',
        borderRadius: '30px',
        backgroundColor: '#3b82f6',
        color: '#ffffff',
        border: 'none',
        cursor: 'pointer',
        zIndex: '1000',
        transition: 'background-color 0.3s, transform 0.3s',
    });

    darkModeButton.addEventListener('mouseenter', () => {
        darkModeButton.style.backgroundColor = '#2563eb';
        darkModeButton.style.transform = 'scale(1.1)';
    });
    darkModeButton.addEventListener('mouseleave', () => {
        darkModeButton.style.backgroundColor = '#3b82f6';
        darkModeButton.style.transform = 'scale(1)';
    });

    document.body.appendChild(darkModeButton);
    const isDarkMode = localStorage.getItem('darkMode') === 'true';

    function applyDarkMode() {
        document.body.style.backgroundColor = '#f3f4f6';
        document.body.style.color = '#1e293b';

        document.querySelectorAll('.swagger-ui, .swagger-ui .btn, .swagger-ui .info, .swagger-ui .section .title, .swagger-ui .operation-description')
            .forEach(e => {
                e.style.color = '#1e293b';
                e.style.borderColor = '#cbd5e1';
            });

        const topbar = document.querySelector('.swagger-ui .topbar');
        if (topbar) topbar.style.backgroundColor = '#e5e7eb';

        const footer = document.querySelector('.swagger-ui > div:last-child');
        if (footer) {
            footer.style.backgroundColor = '#e5e7eb';
            footer.style.color = '#1e293b';
        }

        const searchInput = document.querySelector('input[type="text"][placeholder*="Filter"]');
        if (searchInput) {
            searchInput.style.backgroundColor = '#ffffff';
            searchInput.style.color = '#1e293b';
            searchInput.style.border = '1px solid #cbd5e1';
        }

        document.querySelectorAll('button').forEach(btn => {
            if (btn !== darkModeButton) {
                btn.style.backgroundColor = '#94a3b8';
                btn.style.color = '#ffffff';
                btn.style.border = 'none';
            }
        });

        const scrollTopBtn = document.querySelector('button[style*="Top"]');
        if (scrollTopBtn) {
            scrollTopBtn.style.backgroundColor = '#94a3b8';
            scrollTopBtn.style.color = '#ffffff';
        }

        darkModeButton.innerHTML = '🌞 Light Mode';
    }

    function applyLightMode() {
        document.body.style.backgroundColor = '';
        document.body.style.color = '';

        document.querySelectorAll('.swagger-ui, .swagger-ui .btn, .swagger-ui .info, .swagger-ui .section .title, .swagger-ui .operation-description')
            .forEach(e => {
                e.style.color = '';
                e.style.borderColor = '';
            });

        const topbar = document.querySelector('.swagger-ui .topbar');
        if (topbar) topbar.style.backgroundColor = '';

        const footer = document.querySelector('.swagger-ui > div:last-child');
        if (footer) {
            footer.style.backgroundColor = '';
            footer.style.color = '';
        }

        const searchInput = document.querySelector('input[type="text"][placeholder*="Filter"]');
        if (searchInput) {
            searchInput.style.backgroundColor = '';
            searchInput.style.color = '';
            searchInput.style.border = '';
        }

        document.querySelectorAll('button').forEach(btn => {
            if (btn !== darkModeButton) {
                btn.style.backgroundColor = '';
                btn.style.color = '';
                btn.style.border = '';
            }
        });

        const scrollTopBtn = document.querySelector('button[style*="Top"]');
        if (scrollTopBtn) {
            scrollTopBtn.style.backgroundColor = '';
            scrollTopBtn.style.color = '';
        }

        darkModeButton.innerHTML = '🌙 Dark Mode';
    }

    isDarkMode ? applyDarkMode() : applyLightMode();

    darkModeButton.addEventListener('click', () => {
        const newMode = !(localStorage.getItem('darkMode') === 'true');
        localStorage.setItem('darkMode', newMode.toString());
        newMode ? applyDarkMode() : applyLightMode();
    });

    const interval = setInterval(() => {
        const topbar = document.querySelector('.swagger-ui .topbar');
        const mainWrapper = document.querySelector('.swagger-ui');

        if (topbar && mainWrapper) {
            clearInterval(interval);

            topbar.style.padding = '10px';
            const span = topbar.querySelector('span');
            if (span) {
                span.innerText = '🚀 LogiXplore API Platform';
                span.style.color = '#2563eb';
                span.style.fontSize = '1.5rem';
                span.style.fontWeight = 'bold';
                span.style.letterSpacing = '1px';
            }
            const logo = topbar.querySelector('img');
            if (logo) logo.remove();

            mainWrapper.style.fontFamily = "'Segoe UI', sans-serif";
            mainWrapper.style.padding = '20px';

            document.querySelectorAll('.opblock-summary').forEach(block => {
                block.style.borderRadius = '8px';
                block.style.boxShadow = '0 2px 6px rgba(0,0,0,0.05)';
                block.style.marginBottom = '8px';
            });

            const footer = document.createElement('div');
            footer.innerHTML = `<div style="
                background-color: #f8fafc;
                color: #1e293b;
                text-align: center;
                padding: 15px;
                font-size: 0.95rem;
                margin-top: 40px;
                border-radius: 8px;
            ">
                © 2025 LogiXplore • Powered by Swagger & .NET
            </div>`;
            mainWrapper.appendChild(footer);

            const searchWrapper = document.createElement('div');
            searchWrapper.style.textAlign = 'center';
            searchWrapper.style.margin = '20px auto';

            const searchInput = document.createElement('input');
            searchInput.type = 'text';
            searchInput.placeholder = '🔍 Filter endpoints...';
            Object.assign(searchInput.style, {
                padding: '10px',
                width: '60%',
                border: '1px solid #cbd5e1',
                borderRadius: '8px',
                fontSize: '16px',
                outline: 'none',
                boxShadow: '0 2px 4px rgba(0,0,0,0.05)',
                transition: 'all 0.3s ease',
            });

            const savedQuery = localStorage.getItem('swaggerSearchQuery');
            if (savedQuery) searchInput.value = savedQuery;

            searchInput.addEventListener('input', () => {
                const query = searchInput.value.toLowerCase();
                localStorage.setItem('swaggerSearchQuery', query);
                document.querySelectorAll('.opblock-tag-section').forEach(section => {
                    const tagTitle = section.querySelector('.opblock-tag')?.textContent?.toLowerCase() || '';
                    let visible = false;
                    section.querySelectorAll('.opblock').forEach(op => {
                        const path = op.querySelector('.opblock-summary-path')?.textContent?.toLowerCase() || '';
                        const summary = op.querySelector('.opblock-summary-description')?.textContent?.toLowerCase() || '';
                        const match = path.includes(query) || summary.includes(query) || tagTitle.includes(query);
                        op.style.display = match ? '' : 'none';
                        if (match) visible = true;
                    });
                    section.style.display = visible ? '' : 'none';
                });
            });

            searchWrapper.appendChild(searchInput);
            mainWrapper.insertBefore(searchWrapper, mainWrapper.children[1]);

            if (savedQuery) searchInput.dispatchEvent(new Event('input'));

            const toggleWrapper = document.createElement('div');
            toggleWrapper.style.textAlign = 'center';
            toggleWrapper.style.marginTop = '10px';

            //const expandBtn = document.createElement('button');
            //expandBtn.innerText = '➕ Expand All';
            //const collapseBtn = document.createElement('button');
           // collapseBtn.innerText = '➖ Collapse All';

            //[expandBtn, collapseBtn].forEach(btn => {
            //    Object.assign(btn.style, {
            //        margin: '5px',
            //        padding: '8px 16px',
            //        fontSize: '14px',
            //        backgroundColor: '#3b82f6',
            //        color: '#ffffff',
            //        border: 'none',
            //        borderRadius: '5px',
            //        cursor: 'pointer'
            //    });
            //    toggleWrapper.appendChild(btn);
            //});

            //expandBtn.onclick = () => {
            //    document.querySelectorAll('.opblock').forEach(op => {
            //        if (!op.classList.contains('is-open')) {
            //            op.querySelector('.opblock-summary').click();
            //        }
            //    });
            //};

            //collapseBtn.onclick = () => {
            //    document.querySelectorAll('.opblock.is-open').forEach(op => {
            //        op.querySelector('.opblock-summary').click();
            //    });
            //};

            mainWrapper.insertBefore(toggleWrapper, searchWrapper.nextSibling);

            const scrollTopBtn = document.createElement('button');
            scrollTopBtn.innerText = '⬆ Top';
            Object.assign(scrollTopBtn.style, {
                position: 'fixed',
                bottom: '20px',
                right: '20px',
                padding: '10px 15px',
                fontSize: '14px',
                backgroundColor: '#3b82f6',
                color: '#ffffff',
                border: 'none',
                borderRadius: '20px',
                cursor: 'pointer',
                zIndex: '1000',
                display: 'none'
            });
            document.body.appendChild(scrollTopBtn);

            window.addEventListener('scroll', () => {
                scrollTopBtn.style.display = window.scrollY > 200 ? 'block' : 'none';
            });

            scrollTopBtn.addEventListener('click', () => {
                window.scrollTo({ top: 0, behavior: 'smooth' });
            });

            document.querySelectorAll('.opblock').forEach(op => {
                if (!op.classList.contains('is-open')) {
                    op.querySelector('.opblock-summary').click();
                }
            });

            if (localStorage.getItem('darkMode') === 'true') {
                applyDarkMode();
            } else {
                applyLightMode();
            }
        }
    }, 300);
});
