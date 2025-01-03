document.querySelector(".Apply-btn").addEventListener("click", function (event) {
    console.log("Check");
    event.preventDefault(); // Ngăn việc form submit

    // Lấy giá trị từ dropdown Min và Max
    const minPrice = parseInt(document.querySelector('select[name="minPrice"]').value) || 0;
    const maxPrice = parseInt(document.querySelector('select[name="maxPrice"]').value) || Infinity;

    // Lấy danh sách các sản phẩm
    const products = document.querySelectorAll("#product-list .product");

    // Lọc sản phẩm
    products.forEach(product => {
        const price = parseFloat(product.getAttribute("data-price"));

        // Hiển thị hoặc ẩn sản phẩm dựa trên giá
        if (price >= minPrice && price <= maxPrice) {
            product.style.display = "block";
        } else {
            product.style.display = "none";
        }
    });
});
document.addEventListener("DOMContentLoaded", () => {
    const checkboxes = document.querySelectorAll(".filter-checkbox");
    const products = document.querySelectorAll(".product-item");

    checkboxes.forEach(checkbox => {
        checkbox.addEventListener("change", () => {
            // Lấy danh mục đã chọn
            const selectedCategories = Array.from(checkboxes)
                .filter(cb => cb.checked)
                .map(cb => cb.value);
            console.log(selectedCategories.length);
            // Hiển thị hoặc ẩn sản phẩm dựa trên danh mục
            products.forEach(product => {
                const category = product.getAttribute("data-category");
                if (selectedCategories.length === 0 || selectedCategories.includes(category)) {
                    product.style.display = "block"; // Hiển thị
                } else {
                    product.style.display = "none"; // Ẩn
                }
            });
        });
    });

    // Khi tải trang, đảm bảo hiển thị tất cả sản phẩm
    products.forEach(product => {
        product.style.display = "block";
    });
});
// AJAX 
$(document).ready(function () {
    $('#searchBox').on('input', function () {
        var query = $(this).val();

        if (query.length > 0) {
            $.ajax({
                url: 'https://localhost:7056/api/Product/SearchProduct',
                type: 'GET',
                data: { input: query },
                success: function (data) {
                    $('#results').empty(); // Xóa kết quả cũ
                    data.forEach(function (item) {
                        $('#results').append('<li>' + item + '</li>');
                    });
                },
                error: function (xhr, status, error) {
                    console.error("Search failed: " + error);
                    $('#results').empty().append('<li>Error loading results</li>');
                }
            });
        } else {
            $('#results').empty(); // Xóa kết quả khi ô tìm kiếm rỗng
        }
    });
});