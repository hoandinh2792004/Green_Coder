let checkoutCart = JSON.parse(localStorage.getItem('cartItems')) || {};

function displayCheckoutCart() {
    const cartItemsList = document.getElementById('checkout-cart-items');
    cartItemsList.innerHTML = '';

    Object.entries(checkoutCart).forEach(([productName, productData]) => {
        const listItem = document.createElement('li');
        listItem.classList.add('list-group-item', 'd-flex', 'justify-content-between', 'align-items-center');
        listItem.innerHTML = `
            <div>
                <h6 class="my-0">${productName}</h6>
                <small>${productData.quantity} x ${productData.price.toLocaleString()}đ</small>
            </div>
            <div>
                <button onclick="decreaseItemQuantity('${productName}')">-</button>
                <span>${productData.quantity}</span>
                <button onclick="increaseItemQuantity('${productName}')">+</button>
                <button onclick="removeItem('${productName}')" class="btn btn-danger btn-sm">Xóa</button>
            </div>
            <span>${(productData.price * productData.quantity).toLocaleString()}đ</span>
        `;
        cartItemsList.appendChild(listItem);
    });

    updateTotalPrice();
}

function increaseItemQuantity(productName) {
    if (checkoutCart[productName]) {
        checkoutCart[productName].quantity += 1;
        displayCheckoutCart();
        localStorage.setItem('cartItems', JSON.stringify(checkoutCart));
    }
}

function decreaseItemQuantity(productName) {
    if (checkoutCart[productName] && checkoutCart[productName].quantity > 1) {
        checkoutCart[productName].quantity -= 1;
        displayCheckoutCart();
        localStorage.setItem('cartItems', JSON.stringify(checkoutCart));
    }
}

function removeItem(productName) {
    delete checkoutCart[productName];
    displayCheckoutCart();
    localStorage.setItem('cartItems', JSON.stringify(checkoutCart));
}

function updateTotalPrice() {
    const totalPrice = Object.values(checkoutCart).reduce((total, item) => total + item.price * item.quantity, 0);
    document.getElementById('checkout-total-price').textContent = totalPrice.toLocaleString() + 'đ';
}

document.addEventListener("DOMContentLoaded", function () {
    displayCheckoutCart();
});
