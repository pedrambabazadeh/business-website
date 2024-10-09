import React from 'react'
import './navigation-section.css'
import NavigationStructure from './NavigationStructure'
import { NavBar, Logo } from '../../Components'

export default function NavigationSec() {
  return (
    <NavigationStructure left={<Logo/>} center={<NavBar/>}/>
  )
}
