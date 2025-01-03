const header = document.querySelector("header");
let prevScrollPos = window.scrollY;
window.addEventListener("scroll", () => {
    let CurrentScroll = window.scrollY;
    if (CurrentScroll > prevScrollPos) {
        header.style.transform = `translateY(-105%)`;
    }
    else {
        header.style.transform = `translateY(0)`;

    }
    prevScrollPos = CurrentScroll;
});

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
</script>
