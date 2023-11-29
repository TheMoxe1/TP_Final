const searchInput = document.getElementById('searchInput');
const resultsList = document.getElementById('results');
let libros = []; // Almacenar los libros obtenidos globalmente

// Obtener libros una vez al cargar la página
fetch('/api/buscador/libros')
  .then(response => response.json())
  .then(data => {
    libros = data;
    console.log('Libros cargados:', libros);
  })
  .catch(error => {
    console.error('Error al cargar los libros:', error);
    // Manejo de errores si es necesario
  });

// Realizar la búsqueda al escribir en el input
searchInput.addEventListener('input', function() {
  console.log('Input event triggered'); // Verificar si este mensaje aparece en la consola al escribir
  const searchText = this.value.toLowerCase();
  const filteredResults = libros.filter(libro =>
    libro.Nombre && libro.Nombre.toLowerCase().includes(searchText)
  );  
    
  displayResults(filteredResults);
});


// Ocultar los resultados al salir del input
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
    link.href = '@Url.Action("pantallaLibro", new { L = result.idLibro})'; // Coloca aquí la URL correspondiente a cada resultado
    link.textContent = result.Nombre; // Cambia a la propiedad correcta del libro
    link.classList.add('result-link'); // Clase para los enlaces de resultado
    resultsList.appendChild(link);
  });

  resultsList.style.display = results.length > 0 ? 'block' : 'none';
}
