﻿function SetLimit() {
    let num = document.getElementById("limitInput").value || 50;

    window.location = "https://localhost:7245/Numbers/Limit?num=" + num;
}