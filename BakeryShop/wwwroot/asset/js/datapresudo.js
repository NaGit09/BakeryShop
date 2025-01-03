// Dữ liệu doanh thu
const salesData = [
    { date: "2024-01", revenue: 25 },
    { date: "2024-02", revenue: 39 },
    { date: "2024-03", revenue: 22 },
    { date: "2024-04", revenue: 20 },
    { date: "2024-05", revenue: 43 }
];

// Chuẩn bị dữ liệu cho biểu đồ
const labels = salesData.map(item => item.date); // Ngày tháng
const data = salesData.map(item => item.revenue); // Doanh thu

// Cấu hình biểu đồ
const ctx = document.getElementById('revenueChart').getContext('2d');
new Chart(ctx, {
    type: 'bar', // Loại biểu đồ: cột (bar)
    data: {
        labels: labels,
        datasets: [{
            label: 'Doanh thu (Triệu VND)',
            data: data,
            backgroundColor: 'rgba(54, 162, 235, 0.6)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
                title: {
                    display: true,
                    text: 'Doanh thu (Triệu VND)'
                }
            },
            x: {
                title: {
                    display: true,
                    text: 'Tháng'
                }
            }
        },
        plugins: {
            legend: {
                display: true,
                position: 'top'
            }
        }
    }
});