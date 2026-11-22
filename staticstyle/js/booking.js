document.addEventListener("DOMContentLoaded", () => {
    const startRent = document.getElementById("startRent");
    const endRent = document.getElementById("endRent");
    const priceItems = document.querySelector(".product_price-items");
    const totalDays = document.getElementById("total-days");
    const totalSum = document.getElementById("total-sum");

    if (!startRent || !endRent || !priceItems) return;

    const pricePerDay = parseFloat(priceItems.dataset.price) || 0;
    const deposit = parseFloat(priceItems.dataset.deposit) || 0;

    function recalculate() {
        if (!startRent.value || !endRent.value) return;

        const startDate = new Date(startRent.value);
        const endDate = new Date(endRent.value);

        if (isNaN(startDate.getTime()) || isNaN(endDate.getTime()) || startDate.getFullYear() < 2000 || endDate.getFullYear() < 2000) {
            return;
        }

        let days = Math.round((endDate - startDate) / (1000 * 60 * 60 * 24));

        if (days < 1) {
            days = 1;
            const nextDay = new Date(startDate);
            nextDay.setDate(nextDay.getDate() + 1);
            endRent.value = nextDay.toISOString().split("T");
        }

        const total = days * pricePerDay + deposit;

        totalDays.textContent = days;
        totalSum.textContent = total.toLocaleString("ru-RU");
    }

    startRent.addEventListener("input", recalculate);
    endRent.addEventListener("input", recalculate);
    startRent.addEventListener("change", recalculate);
    endRent.addEventListener("change", recalculate);
    recalculate();
});
