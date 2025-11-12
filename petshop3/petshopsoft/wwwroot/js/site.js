// Основные функции сайта
document.addEventListener('DOMContentLoaded', function () {
    initializeSite();
});

function initializeSite() {
    // Инициализация tooltips
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    const tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    // Плавная прокрутка для якорных ссылок
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Загрузка товаров по категориям
    const categoryButtons = document.querySelectorAll('.category-btn');
    categoryButtons.forEach(btn => {
        btn.addEventListener('click', async function () {
            const category = this.dataset.category;
            await loadProductsByCategory(category);

            // Активный класс для кнопок
            categoryButtons.forEach(b => b.classList.remove('active'));
            this.classList.add('active');
        });
    });
}

async function loadProductsByCategory(category) {
    try {
        const response = await fetch(`/Products/GetProductsByCategory?category=${category}`);
        const products = await response.json();

        const productsContainer = document.getElementById('products-container');
        productsContainer.innerHTML = '';

        products.forEach(product => {
            const productHtml = `
                <div class="col-md-4 mb-4">
                    <div class="card product-card h-100">
                        <img src="${product.imageUrl}" class="card-img-top" alt="${product.name}">
                        <div class="card-body">
                            <h5 class="card-title">${product.name}</h5>
                            <p class="card-text">${product.description}</p>
                            <div class="d-flex justify-content-between align-items-center">
                                <span class="h5 text-primary">${formatPrice(product.price)}</span>
                                <button class="btn btn-outline-primary">В корзину</button>
                            </div>
                        </div>
                    </div>
                </div>
            `;
            productsContainer.innerHTML += productHtml;
        });
    } catch (error) {
        console.error('Error loading products:', error);
    }
}

function formatPrice(price) {
    return new Intl.NumberFormat('ru-RU', {
        style: 'currency',
        currency: 'RUB'
    }).format(price);
}

// Обработка модальных окон
function showServiceDetails(serviceId) {
    fetch(`/Services/GetServiceDetails?id=${serviceId}`)
        .then(response => response.json())
        .then(service => {
            // Показать модальное окно с деталями услуги
            const modal = new bootstrap.Modal(document.getElementById('serviceModal'));
            document.getElementById('serviceModalLabel').textContent = service.title;
            document.getElementById('serviceDescription').textContent = service.description;
            document.getElementById('servicePrice').textContent = formatPrice(service.price);
            document.getElementById('serviceDuration').textContent = service.duration;
            modal.show();
        })
        .catch(error => console.error('Error:', error));
}
