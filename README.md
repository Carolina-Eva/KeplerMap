# 🌌 KeplerMap

**KeplerMap** es una aplicación de escritorio desarrollada como parte de un proyecto académico, cuyo objetivo es permitir la exploración del universo de forma jerárquica y estructurada. La herramienta está pensada para ser utilizada por astrónomos, investigadores y entusiastas del espacio, permitiendo visualizar, clasificar y analizar cuerpos celestes y estructuras astronómicas desde una interfaz intuitiva.

---

## 🎯 Objetivo

Modelar y visualizar la jerarquía del universo, permitiendo **agregar**, **editar** y **eliminar** cuerpos celestes a través de una interfaz amigable.

---

## 🧩 Estructura jerárquica

La estructura del universo se representa como un árbol jerárquico, siguiendo esta composición:

- **Supercúmulo galáctico** → contiene **Cúmulos galácticos**
- **Cúmulo galáctico** → contiene **Galaxias**
- **Galaxia** → contiene **Sistemas solares**
- **Sistema solar** → contiene **Planetas**
- **Planeta** → puede contener **Lunas**

### 🔭 Propiedades de cada componente

- Nombre
- Tipo de objeto astronómico
- Masa estimada
- Distancia relativa a la Tierra
- ¿Posee vida conocida? (booleano)

---

## 🧠 Requerimientos funcionales

- Visualización de la estructura del universo mediante un **TreeView interactivo**.
- Permitir al usuario **agregar, modificar y eliminar** objetos astronómicos según su ubicación jerárquica.
- Mostrar los **detalles** del objeto seleccionado en un panel lateral.
- Calcular la **masa total acumulada** de cualquier nodo (sumando sus hijos recursivamente).
- Implementar **búsqueda por nombre** de objetos celestes.
- **Persistencia de datos** en una base de datos relacional utilizando como máximo **3 tablas**.
- Aplicación basada en una arquitectura en **4 capas**:
  - Capa de Presentación (UI)
  - Capa de Lógica de Negocio (BLL)
  - Capa de Acceso a Datos (DAL)
  - Capa de Entidades (BE)
- Utilización del patrón de diseño **Composite** para modelar la jerarquía de los cuerpos celestes.

---

## 🛠 Tecnologías utilizadas

- C#
- WinForms (.NET 8)
- SQL Server
- Patrón de diseño **Composite**

---

## 🚀 Estado del proyecto

Proyecto en desarrollo académico. Versión inicial enfocada en la estructura y funcionalidad base.

