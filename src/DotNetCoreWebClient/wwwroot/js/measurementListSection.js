class MeasurementListSection {
    addNewMeasurement(measurement) {
        let grid = document.querySelector('#measurements_container')
        let newRow = grid.children[1].cloneNode(true)

        let nameColumn = newRow.querySelector('div[data-columnt-type=\'name\']')
        let valueColumn = newRow.querySelector('div[data-columnt-type=\'value\']')

        nameColumn.innerHTML = measurement.name
        valueColumn.innerHTML = measurement.value


        newRow.classList.remove('d-none')

        grid.appendChild(newRow)
    }
}