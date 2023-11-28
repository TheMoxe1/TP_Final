// Datos de ejemplo (puedes reemplazarlos con tus propios datos)
const data = [
    "algopas",
    "Porqe",
    "x",
    "asdad",
    "vietnar",
    "nose"
  ];
  
  const searchInput = document.getElementById('searchInput');
  const resultsList = document.getElementById('results');
  
  searchInput.addEventListener('input', function() {
    const searchText = this.value.toLowerCase();
    const filteredData = data.filter(item => item.toLowerCase().includes(searchText));
    displayResults(filteredData);
  });
  
  searchInput.addEventListener('blur', function() {
    setTimeout(() => {
      resultsList.innerHTML = '';
      resultsList.style.display = 'none';
    }, 200);
  });
  
  function displayResults(results) {
    resultsList.innerHTML = '';
  
    if (searchInput.value.trim() === '') {
      resultsList.style.display = 'none';
      return;
    }
  
    results.forEach(result => {
      const link = document.createElement('a');
      link.href = '#'; // Coloca aquí la URL correspondiente a cada resultado
      link.textContent = result;
      link.classList.add('result-link'); // Clase para los enlaces de resultado
      resultsList.appendChild(link);
    });
  
    if (results.length > 0) {
      resultsList.style.display = 'block';
    }
  }
  
  