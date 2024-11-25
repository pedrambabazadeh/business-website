import React from 'react'
import './contact-us.css'
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { TextField, Button, Grid2 as Grid, TextareaAutosize} from '@mui/material';
import {default as validationSchema} from './Validation_yup';
import {default as HandleSubmit} from './HandleSubmit'

const ContactUs = () => {
  return (
    <Formik
      initialValues={{
        firstName: '',
        lastName: '',
        email: '',
        companyName: '',
        websiteUrl: '',
        content: '',
        gdpr: false}}
      validationSchema={validationSchema}
      onSubmit={HandleSubmit}
    >
      {({ isSubmitting }) => (
         <Form className='contact-form_form'>
            <Grid container spacing={2}>
              <Grid size={{ xs: 12, md: 6}}>
                <Field
                  as={TextField}
                  fullWidth name="firstName"
                  placeholder="First Name"
                  helperText={<ErrorMessage name="firstName"/>}/>
              </Grid>
              <Grid size={{ xs: 12, md: 6}}>
              <Field
                as={TextField}
                fullWidth name="lastName"
                placeholder="Last Name"
                helperText={<ErrorMessage name="lastName"/>}/>
              </Grid>
              <Grid size={{ xs: 12, md: 6}}>
                <Field
                  as={TextField}
                  fullWidth name="email"
                  type="email"
                  placeholder="Email"
                  helperText={<ErrorMessage name="email"/>}/>
              </Grid>
              <Grid size={{ xs: 12, md: 6}}>
                <Field
                  as={TextField}
                  fullWidth name="companyName"
                  placeholder="Company Name"/>
              </Grid>
              <Grid size={{ xs: 12, md: 6}}>
                <Field
                  as={TextField}
                  fullWidth name="websiteUrl"
                  placeholder="Website URL" />
              </Grid>
              <Grid size={{ xs: 12}}>
                <Field
                  as={TextField}
                  fullWidth name="content"
                  placeholder="Message Content"
                  rows={4}
                  helperText={<ErrorMessage name="content"/>}/>
              </Grid>
            </Grid>
         <label>
           <Field
           type="checkbox"
           name="gdpr" 
           helperText={<ErrorMessage name="gdpr"/>}/>
           Agree to GDPR terms
         </label>
         <Button type="submit" disabled={isSubmitting}>
           Submit
         </Button>
       </Form>
      )}
    </Formik>
  );
};

export default ContactUs;