// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function changeText() {
    document.getElementById("paragraf1").innerHTML = "Hello World";
}

function changeColor() {
    document.getElementById("column2").style.backgroundColor = "lightblue";
}

function changeTextColor() {
    document.getElementById("paragraf3").style.color = "blue";
}

//TUGAS
const animals = [
    { name: "dory", species: "fish", class: { name: "vertebrata" } },
    { name: "tom", species: "cat", class: { name: "mamalia" } },
    { name: "nemo", species: "fish", class: { name: "vertebrata" } },
    { name: "umar", species: "cat", class: { name: "mamalia" } },
    { name: "gary", species: "fish", class: { name: "human" } },
]

//console.log(animals[2].class.name);

//let onlycat = [];
//animals.forEach((animals) => {
//    if (animals.species === "cat") {
//        onlycat.push(animals);
//    }

//    if (animals.species === "fish") {
//        animals.class.name = "cobaobo";
//    }
//});

function filterOnlyCat(animals) {
    const OnlyCat = [];
    animals.forEach(animal => {
        if (animal.species == 'cat') {
            OnlyCat.push(animal);
        }
    });
    return OnlyCat;
}
console.log(filterOnlyCat(animals));
/*const OnlyCat = filterOnlyCat(animals);
console.log(OnlyCat);*/
//filterOnlyCat(animals) //manggil diconsole browser langsung

function changeClass(animals) {
    animals.forEach((animal) => {
        if (animal.species == "fish") {
            animal.class.name = "non-mamalia"
        }
    });
    return animals;
}
console.log(changeClass(animals));

//asynchronus javascript
$.ajax({
    url: "https://swapi.dev/api/people/"
}).done((result) => {
    //console.log(result);
    //console.log(result.results[0].name); //menampilkan naam luke aja
    $.each(result.results, (key, val) => {
        //console.log(val.name); //menampilkan semua  nama
        //console.log(key); //menampilkan index
        //console.log(val); //menampilkan perobjek
    }) 
})

//asynchronus javascript
//$.ajax({
//    url: "https://swapi.dev/api/people/"
//}).done((result) => {
//    let temp = "";
//    $.each(result.results, (key, val) => {
//        //temp += val.name;
//        temp += "<li>"+val.name+"</li>";
//    })
//    //console.log(temp)
//    $("#listSW").html(temp);
//})

//asynchronous javascript
//$.ajax({
//    url: "https://swapi.dev/api/people/"
//}).done((result) => {
//    let temp = "";
//    $.each(result.results, (key, val) => {
//        temp += `
//            <tr>
//                <td>${key+1}</td>
//                <td>${val.name}</td>
//                <td>${val.height}</td>
//                <td>${val.gender}</td>
//                <td>${val.hair_color}</td>
//                <td>${val.skin_color}</td>
//                <td>${val.eye_color}</td>
//            </tr>
//        `;
//    });
//    $("#tbodySW").html(temp);
//});

//fix
//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon/"
//}).done((result) => {
//    let temp = "";
//    $.each(result.results, (key, val) => {
//        temp += `
//            <tr>
//                <td>${key + 1}</td>
//                <td>${val.name}</td>
//                <td><button onclick="detailSW('${val.url}')" data-bs-toggle="modal" data-bs-target="#modalPokemon" class="btn btn-primary">Detail</button></td>
//            </tr>
//        `;
//    });
//    $("#tbodySW").html(temp);
//});

////fix
//function detailSW(stringURL) {
//    $.ajax({
//        url: stringURL,
//        success: (result) => {
//            $('.modal-title').html(result.name);
//            $('#img').attr('src', result.sprites.other['official-artwork'].front_default);
//            $('#name').text(result.name);
//            $('#weight').text(result.weight);
//            $('#height').text(result.height);

//            //List ability
//            const abilitiesList = result.abilities.map((ability) => {
//                return `<li>${ability.ability.name}</li>`;
//            });
//            $('#abilities').html(abilitiesList.join(''));

//            // Update base experience progress bar
//            const baseExperiencePercentage = Math.min((result.base_experience / 255) * 100, 100);
//            $('#experience-progress').attr('style', `width: ${baseExperiencePercentage}%`);
//            $('.progress-text').text(`${baseExperiencePercentage.toFixed(2)}%`);
//        }
//    });
//}

//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon/"
//}).done((result) => {
//    let temp = "";
//    //$.each(result.results, (indeks, val) => {
//    //    temp += `
//    //            <tr>
//    //                <td>${indeks + 1}</td>
//    //                <td>${val.name}</td>
//    //                <td><button onclick="detailPokemon('${val.url}')" data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-primary">Detail</button></td>
//    //            </tr>
//    //        `;
//    //})
//    //$("#tbodySW").html(temp);
//    $.each(result.results, (indeks, val) => {
//        temp += `
//                    <div class="pokemon-card">
//                        <h4 class="pokemon-name">${val.name}</h4>
//                        <button onclick="detailPokemon('${val.url}')" data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-primary">Detail</button>
//                    </div>
//                `;
//    })
//    $("#pokemonContainer").html(temp);
//});


//function detailPokemon(stringURL) {
//    $.ajax({
//        url: stringURL,
//        success: (result) => {


//            $('.modal-title').html(result.name);
//            $('#gambar').attr('src', result.sprites.other['official-artwork'].front_default);
//            $('#name').text(result.name),
//                $('#weight').text(result.weight),
//                $('#height').text(result.height),
//                $('#types').text(result.types);

//            const abilitiesList = result.abilities.map((ability) => {
//                return `<li>${ability.ability.name}</li>`;
//            });
//            $('#abilities').html(abilitiesList.join(''));


//            const baseExperiencePercentage = Math.min((result.base_experience / 255) * 100, 100);
//            $('#experience-progress').attr('style', `width: ${baseExperiencePercentage}%`);
//            $('#experience-progress .progress-text').text(`${baseExperiencePercentage.toFixed(2)}%`);

//            const hpPercentage = Math.min((result.stats[0].base_stat / 255) * 100, 100);
//            $('#hp-progress').attr('style', `width: ${hpPercentage}%`);
//            $('#hp-progress .progress-text').text(`${hpPercentage.toFixed(2)}%`);

//            const attackPercentage = Math.min((result.stats[1].base_stat / 255) * 100, 100);
//            $('#attack-progress').attr('style', `width: ${attackPercentage}%`);
//            $('#attack-progress .progress-text').text(`${attackPercentage.toFixed(2)}%`);

//            const defensePercentage = Math.min((result.stats[2].base_stat / 255) * 100, 100);
//            $('#defense-progress').attr('style', `width: ${defensePercentage}%`);
//            $('#defense-progress .progress-text').text(`${defensePercentage.toFixed(2)}%`);

//            const types = result.types.slice(0, 2).map((typeData) => typeData.type.name);
//            document.getElementById("types").innerText = types.join(" ");

//            const typesList = result.types.map((type) => {
//                return `<span class="badge type-badge ${type.type.name}">${type.type.name}</span>`;
//            });
//            $('#types').html(typesList.join(' '));
//        }
//    });
//}

//// Fungsi untuk mendapatkan URL sprite gambar Pokemon
//function getPokemonSprite(pokemonURL) {
//    const pokemonID = pokemonURL.split("/").slice(-2, -1)[0];
//    return `https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/${pokemonID}.png`;
//}

//$(document).ready(() => {
//    $.ajax({
//        url: "https://pokeapi.co/api/v2/pokemon/"
//    }).done((result) => {
//        let temp = "";
//        $.each(result.results, (indeks, val) => {
//            temp += `
//                        <div class="pokemon-card">
//                            <img class="pokemon-image" src="${getPokemonSprite(val.url)}" alt="${val.name}">
//                            <p class="pokemon-name">${val.name}</p>
//                            <button onclick="detailPokemon('${val.url}')" data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-primary">Detail</button>
//                        </div>
//                    `;
//        });
//        $("#pokemonContainer").html(temp);
//    });
//});

//~~~~~~~~~~~~~~~~~~~~~~~~~POKEMON~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon/"
}).done((result) => {
    console.log(result.results);
    let temp = "";
    $.each(result.results, (key, val) => {
        temp += `<tr>
                    <td>${key + 1}</td>
                    <td>${val.name}</td>
                    <td><button onclick="detail('${val.url}')" data-bs-toggle="modal" data-bs-target="#modal" class="btn btn-warning style="font-weight: bold;">Detail</button></td>
                </tr>`;
    })
    $("#tbody").html(temp);

})

function detail(stringURL) {
    $.ajax({
        url: stringURL
    }).done(res => {
        $("#firstimg").attr("src", res.sprites.other.dream_world.front_default);
        $("#secimg").attr("src", res.sprites.other.home.front_shiny);
        $("#thirdimg").attr("src", res.sprites.other.home.front_default);
        $(".card-title").html(res.name);
        $('#name').text(res.name);
        let temp = "";
        $.each(res.types, (key, val) => {
            temp += `<div class="badge bg-primary"> Type : ${val.type.name}
            </div> `;
        });
        let tempAbility = "";
        $.each(res.abilities, (key, val) => {
            tempAbility += `<div class="badge badge-pill bg-dark"> Ability : ${val.ability.name}</div> `;
        })
        $(".card-text").html(temp);
        $("#listpoke").html(tempAbility);
        $("#listpoke1").html(`<div class="badge bg-primary text-warning"> Weight : ${res.weight} Kg</div> <div class="badge bg-warning text-primary"> Height : ${res.height} M</div>`);
       
        $("#title").html(res.name);
        $("#hp").css("width", res.stats[0].base_stat + "%").html("HP : " + res.stats[0].base_stat);
        $("#attack").css("width", res.stats[1].base_stat + "%").html("Attack : " + res.stats[1].base_stat);
        $("#defense").css("width", res.stats[2].base_stat + "%").html("Defense : " + res.stats[2].base_stat);
        $("#special-attack").css("width", res.stats[3].base_stat + "%").html("Spesial Attack : " + res.stats[3].base_stat);
        $("#special-defense").css("width", res.stats[4].base_stat + "%").html("Spesial Defense : " + res.stats[4].base_stat);
        $("#speed").css("width", res.stats[5].base_stat + "%").html("Speed : " + res.stats[5].base_stat);
    })
}
//$(document).ready(function () {
//    $('#myTabel').DataTable({
//        ajax: {
//            url: "https://pokeapi.co/api/v2/pokemon/",
//            dataType: "JSON",
//            dataSrc: "results" //data source -> butuh array of object
//        },
//        columns: [
//            {
//                data: 'url',

//                render: function (data, type, row) {
//                    let number = data.split('/')[6];
//                    return number;
//                }
//            },
//            { data: "name" },
//            { data: "url" },
//            {
//                data: null,
//                render: function (data, type, row) {
//                    return `<button onclick="detail('${data.url}')" data-bs-toggle="modal" data-bs-target="#modal" class="btn btn-primary">Detail</button>`;
//                }
//            }

//        ]
//    });
//});
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`
//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon/"
//}).done((result) => {
//    let temp = "";
//    $.each(result.results, (key, val) => {
//        const { name } = pokemon;
//        const slideActive = index === 0 ? 'active' : '';
//        carouselIndicatorsHTML += `<li data-target="#pokemonCarousel" data-slide-to="${index}" class="${slideActive}"></li>`;
//        carouselInnerHTML += `
//                            <div class="carousel-item ${slideActive}">
//                                <img src="https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/${index + 1}.png" alt="${name}" style="width: 200px; height: 200px;">
//                                <div class="carousel-caption">
//                                    <h3>${name}</h3>
//                                </div>
//                            </div>
//                        `;
//    });

//    // Append carousel indicators and inner slides to the HTML
//    $('#carouselIndicators').html(carouselIndicatorsHTML);
//    $('#carouselInner').html(carouselInnerHTML);
//});

//function fetchPokemonDataAndCreateCarousel() {
//    const apiUrl = 'https://pokeapi.co/api/v2/pokemon?limit=10'; // Change the limit as needed
//    $.ajax({
//        url: apiUrl,
//        method: 'GET',
//        success: (response) => {
//            const pokemons = response.results;
//            let carouselIndicatorsHTML = '';
//            let carouselInnerHTML = '';

//            // Create carousel indicators and inner slides
//            pokemons.forEach((pokemon, index) => {
//                const { name } = pokemon;
//                const slideActive = index === 0 ? 'active' : '';
//                carouselIndicatorsHTML += `<li data-target="#pokemonCarousel" data-slide-to="${index}" class="${slideActive}"></li>`;
//                carouselInnerHTML += `
//                            <div class="carousel-item ${slideActive}">
//                                <img src="https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/${index + 1}.png" alt="${name}" style="width: 200px; height: 200px;">
//                                <div class="carousel-caption">
//                                    <h3>${name}</h3>
//                                </div>
//                            </div>
//                        `;
//            });

//            // Append carousel indicators and inner slides to the HTML
//            $('#carouselIndicators').html(carouselIndicatorsHTML);
//            $('#carouselInner').html(carouselInnerHTML);
//        },
//        error: (error) => {
//            console.error('Error fetching Pokemon data:', error);
//        }
//    });
//}

//// Call the function to fetch data and create the carousel
//fetchPokemonDataAndCreateCarousel();

//~~~~~~~~~~~~~~~VIEW EMPLOYEE~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
$(document).ready(function () {
    let table = new DataTable('#myTable', {
        ajax: {
            url: "https://localhost:7260/api/employees",
            dataSrc: "data",
            dataType: "JSON"
        },
        columns: [
            /*{ data: "guid" },*/
            {
                data: null,
                render: function (data, type, row, no) {
                    return no.row + 1;
                }
            },
            { data: "nik" },
            {
                data: 'fullName',
                render: function (data, type, row) {
                    return row.firstName + ' ' + row.lastName;
                }
            },
            {
                data: "birthDate",
                render: function (data) {
                    return moment(data).format('DD-MM-YYYY');
                }
            },
            {
                data: 'gender',
                render: function (data, type, row) {
                    return data == 0 ? "Female" : "Male";
                }
            },
            {
                data: "hiringDate",
                render: function (data) {
                    return moment(data).format('DD-MM-YYYY');
                }
            },
            { data: "email" },
            { data: "phoneNumber" },
            {
                data: '',
                render: function (data, type, row) {
                    return `<button onclick="Update('${row.url}')" data-bs-toggle="modal" data-bs-target="" class="btn btn-warning"><i class="fas fa-edit"></i> </button>
                    <button onclick="Delete('${row.url}')" data-bs-toggle="modal" data-bs-target="" class="btn btn-danger"><i class="fas fa-trash"></i> </button>`;
                }
            }
        ],
        dom: 'Blfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });
});

function Insert() {
    var employee = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    employee.FirstName = $("#firstname").val();
    employee.LastName = $("#lastname").val();
    employee.BirthDate = $("#birthdate").val();
    employee.Gender = parseInt($("#gender").val());
    employee.HiringDate = $("#hiringdate").val();
    employee.Email = $("#email").val();
    employee.PhoneNumber = $("#phonenumber").val();
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:7260/api/employees",
        type: "POST",
        //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        data: JSON.stringify(employee), 
        contentType: "application/json",
        dataType: "json"
}).done((result) => {
    //buat alert pemberitahuan jika success
    alert("Employee added successfully");
}).fail((error) => {
    //alert pemberitahuan jika gagal
    alert("Failed add Employee");
})
}

$(document).ready(function () {
    // Fetch data from API
    $.ajax({
        url: "https://localhost:7260/api/employees",
    }).done(function (result) {
        let female = 0;
        let male = 0;

        result.data.forEach(function (dataDetail) {
            if (dataDetail.gender === 0) {
                female++;
            } else if (dataDetail.gender === 1) {
                male++;
            }
        });

        console.log("Total Female", female)
        console.log("Total Male", male)

        // Buat data baru untuk grafik pie berdasarkan data gender yang dihitung
        var genderPieData = {
            labels: ['Female', 'Male'],
            datasets: [
                {
                    data: [female, male],
                    backgroundColor: ['red', 'blue'],
                }
            ]
        };

        // Buat grafik pie
        new Chart(('genderPieChart'), {
            type: 'pie',
            data: genderPieData
        });
    });
});

$(document).ready(function () {
    // Fetch data from API
    $.ajax({
        url: "https://localhost:7260/api/univerities",
    }).done(function (result) {
        let Undika = 0;
        let Stikom = 0;
        let UI = 0;
        let Unsri = 0;
        let UPN = 0;
        let ITS = 0;
        let Others = 0;

        result.data.forEach(function (dataDetail) {
            if (dataDetail.code === 'Undika') {
                Undika++;
            } else if (dataDetail.code === 'Stikom') {
                Stikom++;
            } else if (dataDetail.code === 'UI') {
                UI++;
            } else if (dataDetail.code === 'Unsri') {
                Unsri++;
            } else if (dataDetail.code === 'UPN') {
                UPN++;
            } else if (dataDetail.code === 'ITS') {
                ITS++;
            }
        });

        console.log("Total Undika", Undika)
        console.log("Total Stikom", Stikom)
        console.log("Total UI", UI)
        console.log("Total Unsri", Unsri)
        console.log("Total UPN", UPN)
        console.log("Total ITS", ITS)

        // Buat data baru untuk grafik bar berdasarkan data gender yang dihitung
        var countUnivData = {
            labels: ['Undika', 'Stikom', 'UI', 'Unsri', 'UPN','ITS'],
            datasets: [
                {
                    data: [Undika, Stikom, UI, Unsri, UPN, ITS],
                    backgroundColor: ['red', 'blue', 'yellow', 'green', 'pink','orange'],
                }
            ]
        };

        // Buat grafik pie
        new Chart(('countUnivBar'), {
            type: 'bar',
            data: countUnivData
        });
    });
});

//$(document).ready(function () {
//    // Fetch data from API
//    $.ajax({
//        url: "https://localhost:7260/api/univerities",
//    }).done(function (result) {
//        let age10 = 0;
//        let age20 = 0;

//        const currentDate = new Date();
//        result.data.forEach(function (dataDetail) {
//            const birthDate = new Date(dataDetail.birthDate);
//            const age = currentDate.getFullYear() - birthDate.getFullYear();

//            if (age >= 10 && age >= 20) {
//                age10++;
//            } else {
//                age20++;
//            }
//        });

//        // Buat data baru untuk grafik pie berdasarkan data gender yang dihitung
//        var ageData = {
//            labels: ['10Tahun', '20Tahun'],
//            datasets: [
//                {
//                    data: [age10, age20],
//                    backgroundColor: ['red', 'blue'],
//                }
//            ]
//        };

//        // Buat grafik pie
//        new Chart(('countAgeBar'), {
//            type: 'bar',
//            data: ageData
//        });
//    });
//});

$(document).ready(function ageChart() {
    // Memuat data menggunakan Ajax
    $.ajax({
        url: "https://localhost:7260/api/employees/"
    }).done((result) => {
        // Process the fetched employee data here

        const currentDate = new Date(); // Current date
        const ageCounts = {};

        result.data.forEach(employee => {
            const birthDate = new Date(employee.birthDate);
            const age = currentDate.getFullYear() - birthDate.getFullYear();

            // Counting the occurrences of each age
            if (ageCounts[age]) {
                ageCounts[age]++;
            } else {
                ageCounts[age] = 1;
            }
        });

        var xValues = Object.keys(ageCounts); // Get unique ages
        var yValues = Object.values(ageCounts); // Get counts for each age
        var barColors = ["#b91d47", "#00a5a2", "#f36f6f", "#007acc", "#ffa600"]; // Array of different colors


        new Chart("countAgeBar", {
            type: "bar",
            data: {
                labels: xValues,
                datasets: [{
                    backgroundColor: barColors,
                    data: yValues
                }]
            },
            options: {
                title: {
                    display: true,
                    text: "Employee Age Distribution"
                },
                scales: {
                    x: {
                        title: {
                            display: true,
                            text: "Age"
                        }
                    },
                    y: {
                        title: {
                            display: true,
                            text: "Count"
                        }
                    }
                }
            }
        });
    }).fail((xhr, status, error) => {
        console.error("Error fetching employee data:", error);
    });
});