// ** React Imports
import { useCallback, useState } from 'react'

// ** Third Party Components
import classnames from 'classnames'

// ** Custom Components
import Autocomplete from '@components/autocomplete/AutoCompleteMain'
import { requestSearchQuery } from './apiAutoComplete'

const CustomNavbarSearchMain = () => {
  // ** Store Vars
  const [suggestions, setSuggestions] = useState([])
  // const [term, setTerm] = useState('')
  const [navbarSearch, setNavbarSearch] = useState(false)
  const [loading, setLoading] = useState(false)
  const handleSearchQuery = (val) => {
    if (val === '') {
      setSuggestions([])
      setLoading(false)
    } 
  }
  // useEffect(() => {
  //   setLoading(true)
  //   // const timer = setTimeout(() => {
  //   handleSearchQuery(debouncedTerm)
  //   // }, 200)
  //   // return () => clearTimeout(timer)
  //   return () => {
  //     setSuggestions([])
  //   }
  // }, [debouncedTerm])

  const onSearchSubmit = useCallback(async term => {
    setLoading(true)
    handleSearchQuery(term)
    const data = await requestSearchQuery(term.toLowerCase())
    setSuggestions(data)
    setLoading(false)
  })

  // ** Removes query in store
  const handleClearQueryInStore = () => handleSearchQuery('')

  // ** Function to handle external Input click
  const handleExternalClick = () => {
    if (navbarSearch === true) {
      setNavbarSearch(false)
      handleClearQueryInStore()
    }
  }


  // ** Function to close search on ESC & ENTER Click
  const onKeyDown = e => {
    if (e.keyCode === 27 || e.keyCode === 13) {
      setTimeout(() => {
        setNavbarSearch(false)
        handleClearQueryInStore()
      }, 1)
    }
  }

  // ** Function to handle search suggestion Click
  const handleSuggestionItemClick = () => {
    setNavbarSearch(false)
    handleClearQueryInStore()
  }

  return (
    <div
      className={classnames('search-input', {
        open: navbarSearch === true
      })}
      style={{ width: '600px' }}
    >
      <Autocomplete
        className='form-control text-center'
        suggestions={suggestions}
        filterKey='name_type'
        filterHeaderKey='groupTitle'
        grouped={true}
        placeholder='ابحث...'
        autoFocus={false}
        clearResults={handleClearQueryInStore}
        onSearchSubmit={onSearchSubmit}
        name='aa'
        id='aawee'
        loading={loading}
        onSuggestionItemClick={handleSuggestionItemClick}
        externalClick={handleExternalClick}
        onKeyDown={onKeyDown}
      />
    </div>
  )
}

export default CustomNavbarSearchMain
