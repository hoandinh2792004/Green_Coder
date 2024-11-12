let cartItems = {}; // Giỏ hàng, lưu trữ sản phẩm theo tên sản phẩm

// Hàm thêm sản phẩm vào giỏ hàng
function addToCart(productName, productPrice) {
    if (cartItems[productName]) {
        // Nếu sản phẩm đã có trong giỏ hàng, tăng số lượng lên
        cartItems[productName].quantity += 1;
    } else {
        // Nếu sản phẩm chưa có, thêm sản phẩm mới vào giỏ hàng
        cartItems[productName] = { price: productPrice, quantity: 1 };
    }
    // Cập nhật giỏ hàng
    updateCartDisplay();
}


// Hàm cập nhật giỏ hàng và hiển thị số lượng và tổng giá trị trên giao diện
function updateCartDisplay() {
    // Tính tổng số lượng sản phẩm trong giỏ hàng
    const cartCount = Object.values(cartItems).reduce((total, item) => total + item.quantity, 0);

    // Cập nhật số lượng sản phẩm trong giỏ hàng (ID là 'cart-count')
    document.getElementById('cart-count').textContent = cartCount;

    // Tính tổng giá trị giỏ hàng
    const cartTotalPrice = Object.values(cartItems).reduce((total, item) => total + item.price * item.quantity, 0);
    document.getElementById('cart-total-price').textContent = cartTotalPrice.toLocaleString() + 'đ';

    // Cập nhật danh sách sản phẩm trong giỏ hàng
    const cartItemsList = document.getElementById('cart-items');
    cartItemsList.innerHTML = ''; // Xóa danh sách cũ

    // Cập nhật giỏ hàng hiển thị danh sách sản phẩm
    Object.entries(cartItems).forEach(([productName, productData]) => {
        const listItem = document.createElement('li');
        listItem.classList.add('list-group-item', 'd-flex', 'justify-content-between', 'align-items-center');
        listItem.innerHTML = `
            <div>
                <h6 class="my-0">${productName}</h6>
                <small>${productData.quantity} x ${productData.price.toLocaleString()}đ</small>
            </div>
            <div>
                <button onclick="decreaseQuantity('${productName}')">-</button>
                <span>${productData.quantity}</span>
                <button onclick="increaseQuantity('${productName}')">+</button>
                <button onclick="removeFromCart('${productName}')" class="btn btn-danger btn-sm">Xóa</button>
            </div>
            <span>${(productData.price * productData.quantity).toLocaleString()}đ</span>
        `;
        cartItemsList.appendChild(listItem);
    });
}

// Hàm giảm số lượng sản phẩm trong giỏ hàng
function decreaseQuantity(productName) {
    if (cartItems[productName].quantity > 1) {
        cartItems[productName].quantity -= 1;
        updateCartDisplay();
    }
}

// Hàm tăng số lượng sản phẩm trong giỏ hàng
function increaseQuantity(productName) {
    cartItems[productName].quantity += 1;
    updateCartDisplay();
}

// Hàm xóa sản phẩm khỏi giỏ hàng
function removeFromCart(productName) {
    delete cartItems[productName];
    updateCartDisplay();
}

// Trong cart.js
function getCartItems() {
    // Mã giả để lấy danh sách sản phẩm trong giỏ hàng
    // Bạn cần tùy chỉnh để lấy dữ liệu thực từ giỏ hàng của mình
    return [
        { ProductId: 1, ProductName: "Sản phẩm A", Quantity: 2, Price: 100 },
        { ProductId: 2, ProductName: "Sản phẩm B", Quantity: 1, Price: 200 }
    ];
}

function getTotalPrice() {
    // Tính tổng giá trị của giỏ hàng dựa trên các sản phẩm
    const items = getCartItems();
    return items.reduce((total, item) => total + item.Quantity * item.Price, 0);
}