const searchInput = document.getElementById('searchInput');
const resultsList = document.getElementById('results');
let libros = [];






fetch('/api/buscador/libros')
  .then(response => response.json())
  .then(data => {
    libros = data;
    console.log('Libros cargados:', libros);
  })
  .catch(error => {
    console.error('Error al cargar los libros:', error);

  });


searchInput.addEventListener('input', function() {
  const searchText = this.value.toLowerCase();
  const filteredResults = libros.filter(LibrosBuscador =>
    LibrosBuscador.nombre && LibrosBuscador.nombre.toLowerCase().includes(searchText)
  ); 
  console.log(filteredResults)
  displayResults(filteredResults);
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
    const button = document.createElement('button');
    button.type = 'button';
    button.textContent = result.nombre;
    button.classList.add('result-button');
    resultsList.appendChild(button);

    $(button).on('click', function(event) {
      event.preventDefault();
      const libroId = result.idLibro;
      $.ajax({
        url: `/Home/pantallaLibro?L=${libroId}`,
        type: 'GET',
        contentType: 'application/json',
        success: function(data) {
          window.location.href = `/Home/pantallaLibro?L=${libroId}`;
        },
        error: function(jqXHR, textStatus, errorThrown) {
          console.error('Hubo un error durante la redirección:', errorThrown);
        }
      });
    });
  });

  resultsList.style.display = results.length > 0 ? 'block' : 'none';
}