library rsa_encryption;

import 'package:encrypt/encrypt.dart';
import 'package:pointycastle/export.dart';
import 'package:rsa_encryption/src/environment_configuration.dart';

class RSAEncryption {
  static String encryptedBase64(String data) {
    Encrypter encrypter = _getEncrypter();
    return encrypter.encryptBytes(data.codeUnits).base64;
  }


  static String decryptBase64(String data) {
    return _getEncrypter().decrypt64(data);
  }



  static Encrypter _getEncrypter() {
    final encrypter = Encrypter(RSA(
      privateKey: RSAKeyParser().parse(RSAKey.privateKey) as RSAPrivateKey,
      publicKey: RSAKeyParser().parse(RSAKey.publicKey) as RSAPublicKey,
    ));
    return encrypter;
  }
}
