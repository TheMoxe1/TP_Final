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
  const searchText = this.value.toLowerCase();
  const filteredResults = libros.filter(LibrosBuscador =>
    LibrosBuscador.nombre && LibrosBuscador.nombre.toLowerCase().includes(searchText)
  ); 
  console.log(filteredResults)
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
    const link = document.createElement('button');
    link.onclick="" // Coloca aquí la URL correspondiente a cada resultado
    link.textContent = result.nombre; // Cambia a la propiedad correcta del libro
    link.classList.add('result-link'); // Clase para los enlaces de resultado
    resultsList.appendChild(link);

    link.addEventListener('click', function(event) {
      event.preventDefault(); // Prevenir el comportamiento predeterminado del enlace
      fetch(link.href) // Realizar una solicitud GET a la URL de la API
        .then(response => {
          if (response.ok) {
            return response.json();
          }
          throw new Error('Network response was not ok.');
        })
        .then(data => {
          // Realizar alguna acción adicional si es necesario después de la redirección
          console.log('Redirección exitosa:', data);
        })
        .catch(error => {
          console.error('Hubo un error durante la redirección:', error);
        });
    });
  
    resultsList.appendChild(link);
  });

  resultsList.style.display = results.length > 0 ? 'block' : 'none';
}

//function mandarLibo(IdL){
//    $.ajax(
//      type: "POST",
//      dataType: 'JSON',

//    )
//}