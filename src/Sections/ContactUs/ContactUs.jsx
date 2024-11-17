import React from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { TextField, Button } from '@mui/material';
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
         <Form>
         <Field name="firstName" placeholder="First Name" />
         <Field name="lastName" placeholder="Last Name" />
         <Field name="email" type="email" placeholder="Email" />
         <Field name="companyName" placeholder="Company Name" />
         <Field name="websiteUrl" placeholder="Website URL" />
         <Field name="content" component="textarea" placeholder="Message Content" />
         <label>
           <Field type="checkbox" name="gdpr" />
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
