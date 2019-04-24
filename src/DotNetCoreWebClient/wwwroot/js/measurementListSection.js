class MeasurementListSection {
    addNewMeasurement(measurement) {
        let grid = document.querySelector('#measurements_container')
        let newRow = grid.children[1].cloneNode(true)

        let nameColumn = newRow.querySelector('div[data-column-type=\'name\']')
        let valueColumn = newRow.querySelector('div[data-column-type=\'value\']')
        let removeBtn = newRow.querySelector('a[data-action=\'remove\']')

        nameColumn.innerHTML = measurement.name
        valueColumn.innerHTML = measurement.value
        removeBtn.addEventListener('click', e => {
            //removeBtn.parentElement.parentElement.remove()
            newRow.remove()
        })


        newRow.classList.remove('d-none')

        grid.appendChild(newRow)
    }
}